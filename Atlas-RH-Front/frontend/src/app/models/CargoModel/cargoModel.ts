import { NivelCargo } from './nivel-cargo.enum';

export interface CargoModel {
  id: number;
  nome: string;
  nivel: NivelCargo;
  descricao: string;
}
