import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarFuncionario } from './cadastrar-funcionario';

describe('CadastrarFuncionario', () => {
  let component: CadastrarFuncionario;
  let fixture: ComponentFixture<CadastrarFuncionario>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CadastrarFuncionario]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastrarFuncionario);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
