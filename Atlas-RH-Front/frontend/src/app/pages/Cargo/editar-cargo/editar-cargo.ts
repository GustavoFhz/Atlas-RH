import { Component, OnInit } from '@angular/core';
import { CargoModel } from '../../../models/CargoModel/cargoModel';
import { CargoService } from '../../../services/CargoService/cargo-service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CargoEdicaoDto } from '../../../models/CargoModel/cargoEdicaoDto';
import { CommonModule, NgIf } from '@angular/common';
import { FormularioCargo } from '../../../componentes/formulario-cargo/formulario-cargo';

@Component({
  selector: 'app-editar-cargo',
  imports: [NgIf, CommonModule, FormularioCargo],
  templateUrl: './editar-cargo.html',
  styleUrl: './editar-cargo.css',
})
export class EditarCargo implements OnInit {
  btnAcao = 'Editar';
  descTitulo = 'Editar Cargos';
  cargo!: CargoModel;

  constructor(
    private cargoService: CargoService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.cargoService.BuscarCargoPorId(id).subscribe((response) => {
      this.cargo = response.dados;
    });
  }

  editarCargo(cargo: CargoEdicaoDto) {
    this.cargoService.EditarCargo(cargo).subscribe((response) => {
      if (response.dados != null) {
        this.toastr.success(response.mensagem, 'Sucesso!');
        this.router.navigate(['/homeCargo']);
      } else {
        this.toastr.error(response.mensagem, 'Error!');
      }
    });
  }
}
