import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultOutput } from './result-output';

describe('ResultOutput', () => {
  let component: ResultOutput;
  let fixture: ComponentFixture<ResultOutput>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ResultOutput]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResultOutput);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
