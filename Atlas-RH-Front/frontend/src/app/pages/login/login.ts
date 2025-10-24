import { Component, OnInit } from '@angular/core';
import { Autenticacao } from '../../services/autenticacao';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login implements OnInit {
  loginForm!: FormGroup;
  constructor(
    private autentificacaoService: Autenticacao,
    private formBuilder: FormBuilder,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      usuarioLogin: ['', [Validators.required]],
      senha: ['', [Validators.required]],
    });
  }

  login() {
    this.autentificacaoService.LoginUsuario(this.loginForm.value).subscribe((response) => {
      if (response.dados != null) {
        localStorage.setItem('token', response.dados.token);
        this.toastr.success(response.mensagem, 'Sucesso!');
        this.router.navigate(['/inicio']);
      } else {
        this.toastr.error(response.mensagem, 'Error!');
      }
    });
  }
}
