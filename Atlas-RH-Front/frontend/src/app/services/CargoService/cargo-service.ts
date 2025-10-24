import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Response } from '../../models/reponseModel';
import { CargoModel } from '../../models/CargoModel/cargoModel';
import { CargoEdicaoDto } from '../../models/CargoModel/cargoEdicaoDto';
import { CargoCriacaoDto } from '../../models/CargoModel/cargoCriacaoDto';

@Injectable({
  providedIn: 'root',
})
export class CargoService {
  ApiUrl = environment.UrlApi;

  constructor(private http: HttpClient) {}

  BuscarCargos(): Observable<Response<CargoModel[]>> {
    return this.http.get<Response<CargoModel[]>>(`${this.ApiUrl}/Cargo`);
  }

  RemoverCargo(id: number): Observable<Response<CargoModel>> {
    return this.http.delete<Response<CargoModel>>(`${this.ApiUrl}/Cargo/${id}`);
  }
  BuscarCargoPorId(id: number): Observable<Response<CargoModel>> {
    return this.http.get<Response<CargoModel>>(`${this.ApiUrl}/Cargo/${id}`);
  }
  EditarCargo(cargo: CargoEdicaoDto): Observable<Response<CargoModel>> {
    return this.http.put<Response<CargoModel>>(`${this.ApiUrl}/Cargo`, cargo);
  }

  registrarCargo(cargo: CargoCriacaoDto): Observable<Response<CargoModel>>{
    return this.http.post<Response<CargoModel>>(`${this.ApiUrl}/Cargo`, cargo)
  }
  
}
