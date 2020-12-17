import { SelectNode } from '../../mantenimiento/formularios/tree-datasource';

export class CasiIncidente {
  public id: number;
  public fecha: Date;
  public areaId: number;
  public procesoId: number;
  public observadoId: number;
  public casualidadId: number;
  public turnoId: number;
  public jornadaId: number;
  public riesgoId: number;
  public generoId: number;
  public descripcion: string;

  public actividad?: SelectNode;
  public area?: SelectNode;
  public genero?: SelectNode;
  public riesgo?: SelectNode;
  public jornada?: SelectNode;
  public proceso?: SelectNode;
  public turno?: SelectNode;
  public observado?: any;

  constructor(
    id: number,
    fecha: Date,
    areaId: number,
    procesoId: number,
    observadoId: number,
    casualidadId: number,
    turnoId: number,
    jornadaId: number,
    generoId: number,
    riesgoId: number,
    descripcion: string,
    actividad?: SelectNode,
    area?: SelectNode,
    riesgo?: SelectNode,
    jornada?: SelectNode,
    proceso?: SelectNode,
    turno?: SelectNode,
    genero?: SelectNode
  ) {
    this.id = id;
    this.fecha = fecha;
    this.areaId = areaId;
    this.procesoId = procesoId;
    this.observadoId = observadoId;
    this.generoId = generoId;
    this.casualidadId = casualidadId;
    this.turnoId = turnoId;
    this.jornadaId = jornadaId;
    this.riesgoId = riesgoId;
    this.descripcion = descripcion;
    this.actividad = actividad;
    this.area = area;
    this.riesgo = riesgo;
    this.jornada = jornada;
    this.proceso = proceso;
    this.turno = turno;
    this.genero = genero;
  }
}
