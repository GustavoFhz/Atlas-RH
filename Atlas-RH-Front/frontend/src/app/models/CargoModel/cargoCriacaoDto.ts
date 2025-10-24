import { NivelCargo } from './nivel-cargo.enum';
export interface CargoCriacaoDto {
  nome: string;
  nivel: NivelCargo;
  descricao: string;
}
