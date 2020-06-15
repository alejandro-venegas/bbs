import { Colaborador } from './colaborador.model';

export class Departamento {
  public id: number;
  public nombre: string;
  public gerenteId?: number;
  public gerente?: Colaborador;

  constructor(
    id: number,
    nombre: string,
    gerenteId?: number,
    gerente?: Colaborador
  ) {
    this.id = id;
    this.nombre = nombre;
    this.gerenteId = gerenteId;
    this.gerente = gerente;
  }
}
