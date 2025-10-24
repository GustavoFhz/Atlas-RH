import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { UsuarioModel } from '../../models/UsuarioModel/usuarioModel';
import { environment } from '../../../environments/environment.development';
import { Response } from '../../models/reponseModel';
import { UsuarioEdicaoDto } from '../../models/UsuarioModel/usuarioEdicaoDto';



@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  ApiUrl = environment.UrlApi;

  constructor(private http: HttpClient) {}

  BuscarUsuarios(): Observable<Response<UsuarioModel[]>> {
    return this.http.get<Response<UsuarioModel[]>>(`${this.ApiUrl}/Usuario`);
  }

  RemoverUsuario(id:number) : Observable<Response<UsuarioModel>>{
    return this.http.delete<Response<UsuarioModel>>(`${this.ApiUrl}/Usuario/${id}`);
  }

  BuscarUsuarioPorId(id:number) : Observable<Response<UsuarioModel>>{
    return this.http.get<Response<UsuarioModel>>(`${this.ApiUrl}/Usuario/${id}`);
  }
  EditarUsuario(usuario:UsuarioEdicaoDto):Observable<Response<UsuarioModel>>{
    return this.http.put<Response<UsuarioModel>>(`${this.ApiUrl}/Usuario`,usuario);
  }
  
}
