import { Component, OnInit } from '@angular/core';
import { Formulario } from '../../../componentes/formulario/formulario';

import { ActivatedRoute, Router } from '@angular/router';

import { CommonModule, NgIf } from '@angular/common';

import { ToastrService } from 'ngx-toastr';
import { UsuarioModel } from '../../../models/UsuarioModel/usuarioModel';
import { UsuarioService } from '../../../services/UsuarioService/usuario-service';
import { UsuarioEdicaoDto } from '../../../models/UsuarioModel/usuarioEdicaoDto';

@Component({
  selector: 'app-editar',
  imports: [Formulario, NgIf, CommonModule],
  templateUrl: './editar.html',
  styleUrl: './editar.css',
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
