import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Response } from '../../models/reponseModel';
import { FuncionarioModel } from '../../models/FuncionarioModel/funcionarioModel';
import { FuncionarioEdicaoDto } from '../../models/FuncionarioModel/funcionarioEdicaoDto';
import { FuncionarioCriacaoDto } from '../../models/FuncionarioModel/funcionarioCricaoDto';

@Injectable({
  providedIn: 'root',
})
export class FuncionarioService {
  ApiUrl = environment.UrlApi;

  constructor(private http: HttpClient) {}

  BuscarFuncionarios(): Observable<Response<FuncionarioModel[]>> {
    return this.http.get<Response<FuncionarioModel[]>>(`${this.ApiUrl}/Funcionario`);
  }

  RemoverFuncionario(id: number): Observable<Response<FuncionarioModel>> {
    return this.http.delete<Response<FuncionarioModel>>(`${this.ApiUrl}/Funcionario/${id}`);
  }

  BuscarFuncionarioPorId(id: number): Observable<Response<FuncionarioModel>> {
    return this.http.get<Response<FuncionarioModel>>(`${this.ApiUrl}/Funcionario/${id}`);
  }

  EditarFuncionario(funcionario: FuncionarioEdicaoDto): Observable<Response<FuncionarioModel>> {
    return this.http.put<Response<FuncionarioModel>>(`${this.ApiUrl}/Funcionario`, funcionario);
  }

  RegistrarFuncionario(funcionario: FuncionarioCriacaoDto): Observable<Response<FuncionarioModel>> {
    return this.http.post<Response<FuncionarioModel>>(`${this.ApiUrl}/Funcionario`, funcionario);
  }

  buscarCep(cep: string) {
    return this.http.get<any>(`https://localhost:7030/api/funcionario/cep/${cep}`);
  }
}
