import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CargoCriacaoDto } from '../../models/CargoModel/cargoCriacaoDto';
import { CargoEdicaoDto } from '../../models/CargoModel/cargoEdicaoDto';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NivelCargo } from '../../models/CargoModel/nivel-cargo.enum';

@Component({
  selector: 'app-formulario-cargo',
  imports: [FormsModule, ReactiveFormsModule, CommonModule, RouterModule],
  templateUrl: './formulario-cargo.html',
  styleUrl: './formulario-cargo.css',
})
export class FormularioCargo implements OnInit {
  @Input() btnAcao!: string;
  @Input() descTitulo!: string;
  @Input() dadosCargos: CargoCriacaoDto | CargoEdicaoDto | null = null;
  @Output() onSubmit = new EventEmitter();

  cargoForm!: FormGroup;
  niveis = Object.values(NivelCargo);

  ngOnInit(): void {
    this.cargoForm = new FormGroup({
      id: new FormControl(
        this.dadosCargos && 'id' in this.dadosCargos ? this.dadosCargos.id : null
      ),
      nome: new FormControl(this.dadosCargos?.nome ?? '', Validators.required),
      nivel: new FormControl(this.dadosCargos?.nivel ?? '', Validators.required),
      descricao: new FormControl(this.dadosCargos?.descricao ?? '', Validators.required),
    });
  }

  submit(): void {
    if (this.cargoForm.valid) {
      // Mapeia o enum string para número
      const nivelMap: Record<string, number> = {
        Estagiario: 0,
        Junior: 1,
        Pleno: 2,
        Senior: 3,
        Lider: 4,
        Gerente: 5,
        Diretor: 6,
      };

      const formValue = this.cargoForm.value;

      let payload: CargoCriacaoDto | CargoEdicaoDto;

      if (this.dadosCargos && 'id' in this.dadosCargos) {
        // Para edição
        payload = {
          ...formValue,
          nivel: nivelMap[formValue.nivel], // transforma string em número
        } as CargoEdicaoDto;
      } else {
        // Para cadastro
        const { id, ...rest } = formValue;
        payload = {
          ...rest,
          nivel: nivelMap[rest.nivel], // transforma string em número
        } as CargoCriacaoDto;
      }
      this.onSubmit.emit(payload);
    } else {
      this.cargoForm.markAllAsTouched();
    }
  }
}
