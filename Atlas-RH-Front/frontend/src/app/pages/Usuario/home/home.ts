import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../../services/usuario-service';
import { UsuarioModel } from '../../../models/usuarioModel';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { RouterModule } from '@angular/router';



@Component({
  selector: 'app-home',
  imports: [CommonModule, RouterModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home implements OnInit {
  usuarios: UsuarioModel[] = [];
  usuariosGeral: UsuarioModel[] = [];

  constructor(
    private usuarioService: UsuarioService,
    private toastr: ToastrService,
    
  ) {}

  ngOnInit(): void {
    this.usuarioService.BuscarUsuarios().subscribe((response) => {
      this.usuarios = response.dados;
      this.usuariosGeral = response.dados;
    });
  }

  remover(id: number) {
    this.usuarioService.RemoverUsuario(id).subscribe((response) => {
      if (response.dados != null) {
        this.toastr.success(response.mensagem, 'Sucesso!');
        this.usuarios = this.usuarios.filter((usuario) => usuario.id !== id);
      } else {
        this.toastr.error(response.mensagem, 'Error');
      }
    });
  }
  pesquisar(value: string) {
    const val = value.toLowerCase();
    this.usuarios = this.usuariosGeral.filter((usuario) =>
      usuario.nome.toLowerCase().includes(val)
    );
  }
  
}
