import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Base64 } from './base64';

describe('Base64', () => {
  let component: Base64;
  let fixture: ComponentFixture<Base64>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Base64]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Base64);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
