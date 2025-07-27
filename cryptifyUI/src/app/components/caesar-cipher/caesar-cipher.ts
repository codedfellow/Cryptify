import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Menu } from '../menu/menu';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ResultOutput } from '../result-output/result-output';
import { CaesarCipherService } from '../../services/caesar-cipher.service';

@Component({
  selector: 'app-caesar-cipher',
  imports: [CommonModule, Menu, ReactiveFormsModule, ResultOutput],
  templateUrl: './caesar-cipher.html',
  styleUrl: './caesar-cipher.scss'
})
export class CaesarCipher {
  caesarCipherService = inject(CaesarCipherService)
  fb = inject(FormBuilder);

  isEncryptMode: boolean = true;

  encryptForm = this.fb.group({
    plainText: ['', [Validators.required]],
    shift: [1, [Validators.required, Validators.min(0), Validators.max(25)]],
  })

  decyptForm = this.fb.group({
    cipherText: ['', [Validators.required]],
    shift: [1, [Validators.required, Validators.min(0), Validators.max(25)]],
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
      shift: this.encryptForm.value.shift
    }

    this.caesarCipherService.encrypt(body).subscribe({
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
      shift: this.decyptForm.value.shift,
    }

    this.caesarCipherService.decrypt(body).subscribe({
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
