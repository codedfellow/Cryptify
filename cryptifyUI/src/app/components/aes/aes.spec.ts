import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Aes } from './aes';

describe('Aes', () => {
  let component: Aes;
  let fixture: ComponentFixture<Aes>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Aes]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Aes);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
