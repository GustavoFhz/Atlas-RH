import { Component, OnInit } from '@angular/core';
import { DepartamentoModel } from '../../../models/Departamento/departamentoModel';
import { DepartamentoService } from '../../../services/DepartamentoService/departamento-service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DepartamentoEdicaoDto } from '../../../models/Departamento/DepartamentoEdicaoDto';
import { CommonModule, NgIf } from '@angular/common';
import { FormularioDepartamento } from '../../../componentes/formulario-departamento/formulario-departamento';

@Component({
  selector: 'app-editar-departamento',
  imports: [NgIf, CommonModule, FormularioDepartamento],
  templateUrl: './editar-departamento.html',
  styleUrl: './editar-departamento.css',
})
export class EditarDepartamento implements OnInit {
  btnAcao = 'Editar';
  descTitulo = 'Editar Departamento';
  departamento!: DepartamentoModel;

  constructor(
    private departamentoService: DepartamentoService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.departamentoService.BuscarDepartamentoPorId(id).subscribe((response) => {
      this.departamento = response.dados;
    });
  }

  editarDepartamento(departamento: DepartamentoEdicaoDto) {
    this.departamentoService.EditarDepartamento(departamento).subscribe((response) => {
      if (response.dados != null) {
        this.toastr.success(response.mensagem, 'Sucesso!');
        this.router.navigate(['/homeDepartamento']);
      } else {
        this.toastr.error(response.mensagem, 'Error!');
      }
    });
  }
}
