import { TestBed } from '@angular/core/testing';

import { AesService } from './aes.service';

describe('AesService', () => {
  let service: AesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
