import { Component, OnInit } from '@angular/core';
import { FuncionarioModel } from '../../../models/FuncionarioModel/funcionarioModel';
import { FuncionarioService } from '../../../services/FuncionarioService/funcionario-service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FuncionarioEdicaoDto } from '../../../models/FuncionarioModel/funcionarioEdicaoDto';
import { FormularioFuncionario } from "../../../componentes/formulario-funcionario/formulario-funcionario";
import { CommonModule, NgIf } from '@angular/common';

@Component({
  selector: 'app-editar-funcionario',
  imports: [FormularioFuncionario,NgIf, CommonModule],
  templateUrl: './editar-funcionario.html',
  styleUrl: './editar-funcionario.css',
})
export class EditarFuncionario implements OnInit {
  btnAcao = 'Editar';
  descTitulo = 'Editar Funcionário';
  funcionario!: FuncionarioModel;

  constructor(
    private funcionarioService: FuncionarioService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.funcionarioService.BuscarFuncionarioPorId(id).subscribe((response) => {
      this.funcionario = response.dados;
    });
  }

  editarFuncionario(funcionario: FuncionarioEdicaoDto) {
      this.funcionarioService.EditarFuncionario(funcionario).subscribe((response) => {
        if (response.dados != null) {
          this.toastr.success(response.mensagem, 'Sucesso!');
          this.router.navigate(['/homeFuncionario']);
        } else {
          this.toastr.error(response.mensagem, 'Error!');
        }
      });
    }
}
