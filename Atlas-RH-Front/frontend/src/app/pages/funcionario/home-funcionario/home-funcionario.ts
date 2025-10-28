import { Component, OnInit } from '@angular/core';
import { FuncionarioModel } from '../../../models/FuncionarioModel/funcionarioModel';
import { FuncionarioService } from '../../../services/FuncionarioService/funcionario-service';
import { ToastrService } from 'ngx-toastr';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-home-funcionario',
  imports: [RouterLink,CommonModule],
  templateUrl: './home-funcionario.html',
  styleUrl: './home-funcionario.css',
})
export class HomeFuncionario implements OnInit {
  funcionarios: FuncionarioModel[] = [];
  funcionariosGeral: FuncionarioModel[] = [];
  
  constructor(private funcionarioService: FuncionarioService, private toastr: ToastrService) {}
  
    ngOnInit(): void {
      this.funcionarioService.BuscarFuncionarios().subscribe((response) => {
        this.funcionarios = response.dados;
        this.funcionariosGeral = response.dados;
      });
    }
    pesquisar(value: string) {
      const val = value.toLowerCase();
      this.funcionarios = this.funcionariosGeral.filter((funcionario) => {
        funcionario.nome.toLocaleLowerCase().includes(val);
      });
    }
    remover(id: number) {
      this.funcionarioService.RemoverFuncionario(id).subscribe((response) => {
        if (response.dados != null) {
          this.toastr.success(response.mensagem, 'Sucesso!');
          this.funcionarios = this.funcionarios.filter((funcionario) => funcionario.id !== id);
        } else {
          this.toastr.error(response.mensagem, 'Error!');
        }
      });
    }
}
