import { TestBed } from '@angular/core/testing';

import { XorCipherService } from './xor-cipher.service';

describe('XorCipherService', () => {
  let service: XorCipherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(XorCipherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
