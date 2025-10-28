import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarDepartamento } from './cadastrar-departamento';

describe('CadastrarDepartamento', () => {
  let component: CadastrarDepartamento;
  let fixture: ComponentFixture<CadastrarDepartamento>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CadastrarDepartamento]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastrarDepartamento);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
