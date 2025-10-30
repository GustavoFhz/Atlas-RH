import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DepartamentoCriacoDto } from '../../models/Departamento/departamentoCriacaoDto';
import { DepartamentoEdicaoDto } from '../../models/Departamento/DepartamentoEdicaoDto';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-formulario-departamento',
  imports: [FormsModule, ReactiveFormsModule, CommonModule, RouterModule],
  templateUrl: './formulario-departamento.html',
  styleUrl: './formulario-departamento.css',
})
export class FormularioDepartamento implements OnInit {
  @Input() btnAcao!: string;
  @Input() descTitulo!: string;
  @Input() dadosDepartamentos: DepartamentoCriacoDto | DepartamentoEdicaoDto | null = null;
  @Output() onSubmit = new EventEmitter();

  departamentoFrom!: FormGroup;

  ngOnInit(): void {
   

    this.departamentoFrom = new FormGroup({
      id: new FormControl(
        this.dadosDepartamentos && 'id' in this.dadosDepartamentos ? this.dadosDepartamentos.id : 0
      ),
      nome: new FormControl(this.dadosDepartamentos ? this.dadosDepartamentos.nome : '', [
        Validators.required,
      ]),
      descricao: new FormControl(this.dadosDepartamentos ? this.dadosDepartamentos.descricao : '', [
        Validators.required,
      ]),
    });
  }

  submit(): void {
    if (this.departamentoFrom.valid) {
      if (this.departamentoFrom && (this.departamentoFrom as unknown as DepartamentoEdicaoDto).id) {
        this.onSubmit.emit(this.departamentoFrom.value as DepartamentoEdicaoDto);
      } else {
        this.onSubmit.emit(this.departamentoFrom.value as DepartamentoCriacoDto);
      }
    } else {
      this.departamentoFrom.markAllAsTouched(); //Marca todos os campos que nao digitou com o required
    }
  }
}
