import { TestBed } from '@angular/core/testing';

import { CaesarCipherService } from './caesar-cipher.service';

describe('CaesarCipherService', () => {
  let service: CaesarCipherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CaesarCipherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
