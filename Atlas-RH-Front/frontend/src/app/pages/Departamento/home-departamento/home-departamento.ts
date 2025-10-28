import { Component, OnInit } from '@angular/core';
import { DepartamentoModel } from '../../../models/Departamento/departamentoModel';
import { DepartamentoService } from '../../../services/DepartamentoService/departamento-service';
import { ToastrService } from 'ngx-toastr';

import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-home-departamento',
  imports: [RouterLink],
  templateUrl: './home-departamento.html',
  styleUrl: './home-departamento.css',
})
export class HomeDepartamento implements OnInit {
  departamentos: DepartamentoModel[] = [];
  departamentosGeral: DepartamentoModel[] = [];

  constructor(private departamentoService: DepartamentoService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.departamentoService.BuscarDepartamentos().subscribe((response) => {
      this.departamentos = response.dados;
      this.departamentosGeral = response.dados;
    });
  }
  pesquisar(value: string) {
  const val = value.toLowerCase();
  this.departamentos = this.departamentosGeral.filter((departamento) =>
    departamento.nome.toLowerCase().includes(val)
  );
}
  remover(id: number) {
    this.departamentoService.RemoverDepartamento(id).subscribe((response) => {
      if (response.dados != null) {
        this.toastr.success(response.mensagem, 'Sucesso!');
        this.departamentos = this.departamentos.filter((departamento) => departamento.id !== id);
      } else {
        this.toastr.error(response.mensagem, 'Error!');
      }
    });
  }
}
