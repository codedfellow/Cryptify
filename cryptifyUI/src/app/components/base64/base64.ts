import { Component, inject } from '@angular/core';
import { Menu } from '../menu/menu';
import { Base64Service } from '../../services/base64.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ResultOutput } from '../result-output/result-output';

@Component({
  selector: 'app-base64',
  imports: [CommonModule, Menu, ReactiveFormsModule, ResultOutput],
  templateUrl: './base64.html',
  styleUrl: './base64.scss'
})
export class Base64 {
  base64Service = inject(Base64Service);
  fb = inject(FormBuilder);

  isEncodingMode = true
  result: string | null = null;

  encodingForm = this.fb.group({
    textToEncode: ['',[Validators.required]],
  })
  

  decodingForm = this.fb.group({
    base64Text: ['',[Validators.required]],
  })

  onEncode(){
    let body: any = {
      textToEncode: this.encodingForm.value.textToEncode
    }

    this.base64Service.encodeToBase64(body).subscribe({
      next: (response) => {
        this.result = response.data;
      },
      error: (error) => {
        console.error('Encoding error:', error);
        this.result = null;
      }
    })
  }

  enterEncodingMode() {
    this.isEncodingMode = true;
    this.encodingForm.reset();
    this.decodingForm.reset();
    this.result = null;
  }

  enterDecodingMode() {
    this.isEncodingMode = false;
    this.encodingForm.reset();
    this.decodingForm.reset();
    this.result = null;
  }

  onDecode() {
    let body: any = {
      base64Text: this.decodingForm.value.base64Text
    }

    this.base64Service.decodeBase64Text(body).subscribe({
      next: (response) => {
        this.result = response.data;
      },
      error: (error) => {
        console.error('Decoding error:', error);
        this.result = null;
      }
    })
  }
}
