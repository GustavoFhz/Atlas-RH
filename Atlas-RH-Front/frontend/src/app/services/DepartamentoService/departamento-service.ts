import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { DepartamentoModel } from '../../models/Departamento/departamentoModel';
import { Observable } from 'rxjs';
import { Response } from '../../models/reponseModel';
import { DepartamentoEdicaoDto } from '../../models/Departamento/DepartamentoEdicaoDto';
import { DepartamentoCriacoDto } from '../../models/Departamento/departamentoCriacaoDto';

@Injectable({
  providedIn: 'root',
})
export class DepartamentoService {
  ApiUrl = environment.UrlApi;

  constructor(private http: HttpClient) {}

  BuscarDepartamentos(): Observable<Response<DepartamentoModel[]>> {
    return this.http.get<Response<DepartamentoModel[]>>(`${this.ApiUrl}/Departamento`);
  }

  RemoverDepartamento(id: number): Observable<Response<DepartamentoModel>> {
    return this.http.delete<Response<DepartamentoModel>>(`${this.ApiUrl}/Departamento/${id}`);
  }

  BuscarDepartamentoPorId(id: number): Observable<Response<DepartamentoModel>> {
    return this.http.get<Response<DepartamentoModel>>(`${this.ApiUrl}/Departamento/${id}`);
  }
  EditarDepartamento(departamento: DepartamentoEdicaoDto): Observable<Response<DepartamentoModel>> {
    return this.http.put<Response<DepartamentoModel>>(`${this.ApiUrl}/Departamento`, departamento);
  }
  RegistrarDepartamento(
    departamento: DepartamentoCriacoDto
  ): Observable<Response<DepartamentoModel>> {
    return this.http.post<Response<DepartamentoModel>>(`${this.ApiUrl}/Departamento`, departamento);
  }
}
