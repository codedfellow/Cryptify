import { Component, ElementRef, Input, input, ViewChild } from '@angular/core';

@Component({
  selector: 'app-result-output',
  imports: [],
  templateUrl: './result-output.html',
  styleUrl: './result-output.scss'
})
export class ResultOutput {
  @Input() result: any | null = null;
  @ViewChild('outputText') outputTextRef?: ElementRef<HTMLDivElement>;
  @ViewChild('copyFeedback') copyFeedbackRef?: ElementRef<HTMLDivElement>;

  copyToClipboard() {
    console.log('entered copy method');
    const outputText = this.outputTextRef?.nativeElement.innerText ?? '';
    console.log('out text:', outputText);
    navigator.clipboard.writeText(outputText).then(() => {
      const feedback = this.copyFeedbackRef?.nativeElement!;
      feedback.style.display = 'block';
      setTimeout(() => {
        feedback.style.display = 'none';
      }, 2000);
    }).catch(err => {
      console.error('Failed to copy: ', err);
      alert('Failed to copy text to clipboard.');
    });
  }
}
