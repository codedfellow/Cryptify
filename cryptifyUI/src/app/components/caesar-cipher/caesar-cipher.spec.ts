import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaesarCipher } from './caesar-cipher';

describe('CaesarCipher', () => {
  let component: CaesarCipher;
  let fixture: ComponentFixture<CaesarCipher>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CaesarCipher]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CaesarCipher);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
