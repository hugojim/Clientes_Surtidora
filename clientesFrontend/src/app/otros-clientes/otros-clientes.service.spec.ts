import { TestBed } from '@angular/core/testing';

import { OtrosClientesService } from './otros-clientes.service';

describe('OtrosClientesService', () => {
  let service: OtrosClientesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OtrosClientesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
