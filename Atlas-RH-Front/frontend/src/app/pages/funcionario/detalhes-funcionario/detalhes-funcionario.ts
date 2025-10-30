import { Component, OnInit } from '@angular/core';
import { FuncionarioModel } from '../../../models/FuncionarioModel/funcionarioModel';
import { FuncionarioService } from '../../../services/FuncionarioService/funcionario-service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-detalhes-funcionario',
  imports: [RouterModule, CommonModule],
  templateUrl: './detalhes-funcionario.html',
  styleUrl: './detalhes-funcionario.css',
})
export class DetalhesFuncionario implements OnInit {
  funcionario!: FuncionarioModel;

  constructor(private funcionarioService: FuncionarioService, private route: ActivatedRoute) {}
  statusMap = {
    0: 'Ativo',
    1: 'Inativo',
    2: 'Férias',
    3: 'Afastado',
  };

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.funcionarioService.BuscarFuncionarioPorId(id).subscribe((response) => {
      this.funcionario = response.dados;   

    });
  }
}
