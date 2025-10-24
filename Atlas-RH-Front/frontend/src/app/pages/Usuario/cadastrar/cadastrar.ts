import { Component } from '@angular/core';
import { Formulario } from '../../../componentes/formulario/formulario';
import { UsuarioCriacaoDto } from '../../../models/usuarioCriacaoDto';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Autenticacao } from '../../../services/autenticacao';

@Component({
  selector: 'app-cadastrar',
  imports: [Formulario],
  templateUrl: './cadastrar.html',
  styleUrl: './cadastrar.css',
})
export class Cadastrar {
  btnAcao = 'Cadastrar';
  descTitulo = 'Cadastrar Usuários';

  constructor(
    private autenticacaoService: Autenticacao,
    private router: Router,
    private toastr: ToastrService
  ) {}

  criarUsuario(usuario: UsuarioCriacaoDto) {
    this.autenticacaoService.registrarUsuario(usuario).subscribe((response) => {
      if (response.dados != null) {
        this.toastr.success(response.mensagem, 'Sucesso!');
        this.router.navigate(['/']);
      } else {
        this.toastr.error(response.mensagem, 'Error!');
      }
    });
  }
}
