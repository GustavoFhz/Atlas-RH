import { CargoModel } from '../CargoModel/cargoModel';
import { DepartamentoModel } from '../Departamento/departamentoModel';
import { StatusFuncionario } from './status-funcionario.enum';

export interface FuncionarioModel {
  id: number;
  nome: string;
  cpf: string;
  email: string;
  salario: number;
  dataAdmissao: Date;
  status: StatusFuncionario;
  cep: string;
  logradouro: string;
  bairro: string;
  cidade: string;
  uf: string;
  departamentoId: number;
  departamento?: DepartamentoModel;
  cargoId: number;
  cargo?: CargoModel;

  
}
