import { StatusFuncionario } from './status-funcionario.enum';

export interface FuncionarioCriacaoDto {
  nome: string;
  cpf: string;
  email: string;
  salario: number;
  dataAdmissao: Date;
  status: StatusFuncionario;
  cep: string;
  departamentoId: number;
  cargoId: number;
}
