import { NivelCargo } from './nivel-cargo.enum';

export interface CargoEdicaoDto {
  id: number;
  nome: string;
  nivel: NivelCargo;
  descricao: string;
}
