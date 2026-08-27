import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndiceOtrosClientesComponent } from './indice-otros-clientes.component';

describe('IndiceOtrosClientesComponent', () => {
  let component: IndiceOtrosClientesComponent;
  let fixture: ComponentFixture<IndiceOtrosClientesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IndiceOtrosClientesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IndiceOtrosClientesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
