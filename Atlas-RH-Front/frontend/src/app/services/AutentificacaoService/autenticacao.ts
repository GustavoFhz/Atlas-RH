import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Router } from '@angular/router';
import { environment } from '../../../environments/environment.development';
import { UsuarioCriacaoDto } from '../../models/UsuarioModel/usuarioCriacaoDto';
import { UsuarioModel } from '../../models/UsuarioModel/usuarioModel';
import { Response } from '../../models/reponseModel';
import { UsuarioLoginDto } from '../../models/UsuarioModel/usuarioLoginDto';

@Injectable({
  providedIn: 'root',
})
export class Autenticacao {
  ApiUrl = environment.UrlApi;

  constructor(private http: HttpClient, private router: Router) {}

  registrarUsuario(usuario: UsuarioCriacaoDto): Observable<Response<UsuarioModel>> {
    return this.http.post<Response<UsuarioModel>>(`${this.ApiUrl}/Login/Register`, usuario);
  }
  LoginUsuario(usuarioLogin: UsuarioLoginDto): Observable<Response<UsuarioModel>> {
    return this.http.post<Response<UsuarioModel>>(`${this.ApiUrl}/Login/Login`, usuarioLogin);
  }

  Sair() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
