import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioDepartamento } from './formulario-departamento';

describe('FormularioDepartamento', () => {
  let component: FormularioDepartamento;
  let fixture: ComponentFixture<FormularioDepartamento>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormularioDepartamento]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioDepartamento);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
