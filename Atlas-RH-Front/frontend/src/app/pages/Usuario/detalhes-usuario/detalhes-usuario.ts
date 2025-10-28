import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, RouterModule } from '@angular/router';

import { CommonModule } from '@angular/common';
import { UsuarioModel } from '../../../models/UsuarioModel/usuarioModel';
import { UsuarioService } from '../../../services/UsuarioService/usuario-service';

@Component({
  selector: 'app-detalhes-usuario',
  imports: [RouterModule, CommonModule],
  templateUrl: './detalhes-usuario.html',
  styleUrl: './detalhes-usuario.css',
})
export class Detalhes implements OnInit {
  usuario!: UsuarioModel;

  constructor(private usuarioService: UsuarioService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.usuarioService.BuscarUsuarioPorId(id).subscribe((response) => {
      this.usuario = response.dados;
    });
  }
}
