import { Component, inject } from '@angular/core';
import { Menu } from '../menu/menu';
import { AesService } from '../../services/aes.service';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ResultOutput } from '../result-output/result-output';

@Component({
  selector: 'app-aes',
  imports: [CommonModule, Menu, ReactiveFormsModule, ResultOutput],
  templateUrl: './aes.html',
  styleUrl: './aes.scss'
})
export class Aes {
  aesService = inject(AesService)
  fb = inject(FormBuilder);

  isEncryptMode: boolean = true;

  encryptForm = this.fb.group({
    plainText: ['', [Validators.required]],
    key: ['', [Validators.required]],
  })

  decyptForm = this.fb.group({
    cipherText: ['', [Validators.required]],
    key: ['', [Validators.required]],
    iv: ['', [Validators.required]],
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

    this.aesService.encrypt(body).subscribe({
      next: (response) => {
        this.result = JSON.stringify(response.data);
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
      iv: this.decyptForm.value.iv
    }

    this.aesService.decrypt(body).subscribe({
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
