import { Component, inject } from '@angular/core';
import { XorCipherService } from '../../services/xor-cipher.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Menu } from "../menu/menu";
import { CommonModule } from '@angular/common';
import { ResultOutput } from '../result-output/result-output';

@Component({
  selector: 'app-xor-cipher',
  imports: [CommonModule, Menu, ReactiveFormsModule, ResultOutput],
  templateUrl: './xor-cipher.html',
  styleUrl: './xor-cipher.scss'
})
export class XorCipher {
  xorCipherService = inject(XorCipherService)
  fb = inject(FormBuilder);

  isEncryptMode: boolean = true;

  encryptForm = this.fb.group({
    plainText: ['', [Validators.required]],
    key: ['', [Validators.required]],
  })

  decyptForm = this.fb.group({
    cipherText: ['', [Validators.required]],
    key: ['', [Validators.required]],
  })

  result: any | null = null;

  enterEncryptionMode() {
    this.isEncryptMode = true;
    this.encryptForm.reset();
    this.decyptForm.reset();
    this.result = null;
  }

  enterDecryptionMode() {
    this.isEncryptMode = false;
    this.encryptForm.reset();
    this.decyptForm.reset();
    this.result = null;
  }

  onEncrypt() {
    let body: any = {
      plainText: this.encryptForm.value.plainText,
      key: this.encryptForm.value.key
    }

    this.xorCipherService.encrypt(body).subscribe({
      next: (response) => {
        this.result = response.data;
      },
      error: (error) => {
        console.error('Encryption error:', error);
        this.result = null;
      }
    })
  }

  onDecrypt() {
    let body: any = {
      cipherText: this.decyptForm.value.cipherText,
      key: this.decyptForm.value.key,
    }

    this.xorCipherService.decrypt(body).subscribe({
      next: (response) => {
        this.result = response.data;
      },
      error: (error) => {
        console.error('Decryption error:', error);
        this.result = null;
      }
    })
  }
}
