export class Bbs {
  id: number;
  fechaBbs: Date;
  areaId: number;
  observadorId: number;
  descripcion: number;
  procesoId: number;
  comportamientoId: number;
  tipoObservadoId: number;

  constructor(
    id: number,
    fechaBbs: Date,
    areaId: number,
    observadorId: number,
    descripcion: number,
    procesoId: number,
    comportamientoId: number,
    tipoObservadoId: number,
    tipoComportamientoId: number
  ) {
    this.id = id;
    this.fechaBbs = fechaBbs;
    this.areaId = areaId;
    this.observadorId = observadorId;
    this.descripcion = descripcion;
    this.procesoId = procesoId;
    this.comportamientoId = comportamientoId;
    this.tipoObservadoId = tipoObservadoId;
    this.tipoComportamientoId = tipoComportamientoId;
  }

  tipoComportamientoId: number;
}
