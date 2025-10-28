import { StatusFuncionario } from "./status-funcionario.enum";

export interface FuncionarioEdicaoDto {
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
  cargoId: number;
}
