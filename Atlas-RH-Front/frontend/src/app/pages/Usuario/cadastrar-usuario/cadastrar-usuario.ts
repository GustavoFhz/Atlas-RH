import { Component } from '@angular/core';


import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Autenticacao } from '../../../services/AutentificacaoService/autenticacao';
import { UsuarioCriacaoDto } from '../../../models/UsuarioModel/usuarioCriacaoDto';
import { FormularioUsuario } from '../../../componentes/formulario-usuario/formulario-usuario';




@Component({
  selector: 'app-cadastrar',
  imports: [FormularioUsuario],
  templateUrl: './cadastrar-usuario.html',
  styleUrl: './cadastrar-usuario.css',
})
export class CadastrarUsuario {
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
        this.router.navigate(['/HomeUsuario']);
      } else {
        this.toastr.error(response.mensagem, 'Error!');
      }
    });
  }

  
}
