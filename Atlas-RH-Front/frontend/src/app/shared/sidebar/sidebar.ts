import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Autenticacao } from '../../services/autenticacao';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-sidebar',
  imports: [ CommonModule],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css'
})
export class Sidebar {
  
   constructor(private router: Router, private autenticacaoService: Autenticacao) {}

  deslogar() {
    this.autenticacaoService.Sair();
     // Força recarregar para limpar cache de rotas protegidas
     this.router.navigate(['/login']).then(() => window.location.reload());
  }

  irParaHome() {
    this.router.navigate(['/home']);
  }
}
