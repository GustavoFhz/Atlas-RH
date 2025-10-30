import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FuncionarioCriacaoDto } from '../../models/FuncionarioModel/funcionarioCricaoDto';
import { FuncionarioEdicaoDto } from '../../models/FuncionarioModel/funcionarioEdicaoDto';
import { StatusFuncionario } from '../../models/FuncionarioModel/status-funcionario.enum';
import { FuncionarioService } from '../../services/FuncionarioService/funcionario-service';
import { DepartamentoModel } from '../../models/Departamento/departamentoModel';
import { CargoModel } from '../../models/CargoModel/cargoModel';
import { DepartamentoService } from '../../services/DepartamentoService/departamento-service';
import { CargoService } from '../../services/CargoService/cargo-service';

@Component({
  selector: 'app-formulario-funcionario',
  imports: [FormsModule, ReactiveFormsModule, CommonModule, RouterModule],
  templateUrl: './formulario-funcionario.html',
  styleUrls: ['./formulario-funcionario.css'],
})
export class FormularioFuncionario implements OnInit {
  @Input() btnAcao!: string;
  @Input() descTitulo!: string;
  @Input() dadosFuncionarios: FuncionarioCriacaoDto | FuncionarioEdicaoDto | null = null;
  @Output() onSubmit = new EventEmitter<FuncionarioCriacaoDto | FuncionarioEdicaoDto>();

  departamentos: DepartamentoModel[] = [];
  cargos: CargoModel[] = [];

  funcionarioForm!: FormGroup;
  status = Object.keys(StatusFuncionario).filter((k) => isNaN(Number(k)));

  constructor(
    private funcionarioService: FuncionarioService,
    private departamentoService: DepartamentoService,
    private cargoService: CargoService
  ) {}

  ngOnInit(): void {
     

    this.funcionarioForm = new FormGroup({
      id: new FormControl(
        this.dadosFuncionarios && 'id' in this.dadosFuncionarios ? this.dadosFuncionarios.id : null
      ),
      nome: new FormControl(this.dadosFuncionarios?.nome ?? '', Validators.required),
      cpf: new FormControl(this.dadosFuncionarios?.cpf ?? '', Validators.required),
      email: new FormControl(this.dadosFuncionarios?.email ?? '', [
        Validators.required,
        Validators.email,
      ]),
      salario: new FormControl(this.dadosFuncionarios?.salario ?? 0, Validators.required),
      dataAdmissao: new FormControl(new Date(), Validators.required),
      status: new FormControl(this.dadosFuncionarios?.status ?? '', Validators.required),
      cep: new FormControl(this.dadosFuncionarios?.cep ?? '', Validators.required),

      // Endereço preenchido via API
      logradouro: new FormControl(
        this.dadosFuncionarios && 'logradouro' in this.dadosFuncionarios
          ? this.dadosFuncionarios.logradouro
          : '',
        Validators.required
      ),
      bairro: new FormControl(
        this.dadosFuncionarios && 'bairro' in this.dadosFuncionarios
          ? this.dadosFuncionarios.bairro
          : '',
        Validators.required
      ),
      cidade: new FormControl(
        this.dadosFuncionarios && 'cidade' in this.dadosFuncionarios
          ? this.dadosFuncionarios.cidade
          : '',
        Validators.required
      ),
      uf: new FormControl(
        this.dadosFuncionarios && 'uf' in this.dadosFuncionarios ? this.dadosFuncionarios.uf : '',
        Validators.required
      ),

      departamentoId: new FormControl(
        this.dadosFuncionarios?.departamentoId ?? null,
        Validators.required
      ),
      cargoId: new FormControl(this.dadosFuncionarios?.cargoId ?? null, Validators.required),
    });

    this.departamentoService.BuscarDepartamentos().subscribe({
      next: (response) => {
        this.departamentos = response.dados ?? response;
      },
    });

    this.cargoService.BuscarCargos().subscribe({
      next: (response) => {
        this.cargos = response.dados ?? response;
      },
    });
  }

  submit(): void {
    if (!this.funcionarioForm.valid) {
      this.funcionarioForm.markAllAsTouched();
      return;
    }

    const statusMap: Record<string, number> = { Ativo: 0, Inativo: 1, Ferias: 2, Afastado: 3 };
    const formValue = this.funcionarioForm.value;

    let payload: FuncionarioCriacaoDto | FuncionarioEdicaoDto;
    if (this.dadosFuncionarios && 'id' in this.dadosFuncionarios) {
      payload = { ...formValue, status: statusMap[formValue.status] } as FuncionarioEdicaoDto;
    } else {
      const { id, ...rest } = formValue;
      payload = { ...rest, status: statusMap[rest.status] } as FuncionarioCriacaoDto;
    }

    this.onSubmit.emit(payload);
  }

  buscarCep() {
    let cep = this.funcionarioForm.get('cep')?.value;
    if (!cep) return;

    // Remove tudo que não é número
    cep = cep.replace(/\D/g, '');
    if (cep.length !== 8) return;

    this.funcionarioService.buscarCep(cep).subscribe({
      next: (response: any) => {
        // Se o backend retornar ResponseModel, use response.dados
        const endereco = response.dados ?? response;

        if (!endereco) return;

        this.funcionarioForm.patchValue({
          logradouro: endereco.logradouro,
          bairro: endereco.bairro,
          cidade: endereco.cidade,
          uf: endereco.uf,
        });
      },
      error: () => console.log('CEP não encontrado'),
    });
  }
}
