import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../../services/usuario-service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { UsuarioModel } from '../../../models/usuarioModel';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-detalhes',
  imports: [RouterModule, CommonModule],
  templateUrl: './detalhes.html',
  styleUrl: './detalhes.css',
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
