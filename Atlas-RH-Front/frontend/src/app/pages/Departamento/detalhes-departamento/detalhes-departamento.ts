import { Component, OnInit } from '@angular/core';
import { DepartamentoModel } from '../../../models/Departamento/departamentoModel';
import { DepartamentoService } from '../../../services/DepartamentoService/departamento-service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-detalhes-departamento',
  imports: [RouterModule, CommonModule],
  templateUrl: './detalhes-departamento.html',
  styleUrl: './detalhes-departamento.css',
})
export class DetalhesDepartamento implements OnInit {
  departamento!: DepartamentoModel;

  constructor(private departamentoService: DepartamentoService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.departamentoService.BuscarDepartamentoPorId(id).subscribe((response) => {
      this.departamento = response.dados;
    });
  }
}
