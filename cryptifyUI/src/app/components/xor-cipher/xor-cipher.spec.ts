import { ComponentFixture, TestBed } from '@angular/core/testing';

import { XorCipher } from './xor-cipher';

describe('XorCipher', () => {
  let component: XorCipher;
  let fixture: ComponentFixture<XorCipher>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [XorCipher]
    })
    .compileComponents();

    fixture = TestBed.createComponent(XorCipher);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
