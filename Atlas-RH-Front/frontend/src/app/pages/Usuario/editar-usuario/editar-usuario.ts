import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';

import { CommonModule, NgIf } from '@angular/common';

import { ToastrService } from 'ngx-toastr';
import { UsuarioModel } from '../../../models/UsuarioModel/usuarioModel';
import { UsuarioService } from '../../../services/UsuarioService/usuario-service';
import { UsuarioEdicaoDto } from '../../../models/UsuarioModel/usuarioEdicaoDto';
import { FormularioUsuario } from '../../../componentes/formulario-usuario/formulario-usuario';

@Component({
  selector: 'app-editar-usuario',
  imports: [FormularioUsuario, NgIf, CommonModule],
  templateUrl: './editar-usuario.html',
  styleUrl: './editar-usuario.css',
})
export class Editar implements OnInit {
  btnAcao = 'Editar';
  descTitulo = 'Editar Usuários';
  usuario!: UsuarioModel;

  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.usuarioService.BuscarUsuarioPorId(id).subscribe((response) => {
      this.usuario = response.dados;
    });
  }
  editarUsuario(usuario: UsuarioEdicaoDto) {
    this.usuarioService.EditarUsuario(usuario).subscribe((response) => {
      if (response.dados != null) {
        this.toastr.success(response.mensagem, 'Sucesso!');
        this.router.navigate(['/']);
      } else {
        this.toastr.error(response.mensagem, 'Error!');
      }
    });
  }
}
