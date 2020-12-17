import { SelectNode } from '../../mantenimiento/formularios/tree-datasource';

export class Incidente {
  public id: number;
  public fecha: Date;
  public areaId: number;
  public procesoId: number;
  public observadoId: number;
  public generoId: number;
  public turnoId: number;
  public jornadaId: number;
  public efectoId: number;
  public clasificacionId: number;
  public actividadId: number;
  public riesgoId: number;
  public causaBasicaId: number;
  public causaInmediataId: number;
  public parteCuerpoId: number;
  public descripcion: string;

  public actividad: SelectNode;
  public area: SelectNode;
  public causaBasica: SelectNode;
  public causaInmediata: SelectNode;
  public parteCuerpo: SelectNode;
  public clasificacion: SelectNode;
  public riesgo: SelectNode;
  public efecto: SelectNode;
  public genero: SelectNode;
  public jornada: SelectNode;
  public proceso: SelectNode;
  public turno: SelectNode;
  public observado: any;

  constructor(
    id: number,
    fecha: Date,
    areaId: number,
    procesoId: number,
    observadoId: number,
    generoId: number,
    turnoId: number,
    jornadaId: number,
    efectoId: number,
    clasificacionId: number,
    actividadId: number,
    riesgoId: number,
    causaBasicaId: number,
    causaInmediataId: number,
    parteCuerpoId: number,
    descripcion: string,
    actividad?: SelectNode,
    area?: SelectNode,
    causaBasica?: SelectNode,
    causaInmediata?: SelectNode,
    parteCuerpo?: SelectNode,
    clasificacion?: SelectNode,

    riesgo?: SelectNode,
    efecto?: SelectNode,
    genero?: SelectNode,
    jornada?: SelectNode,
    proceso?: SelectNode,
    turno?: SelectNode
  ) {
    this.id = id;
    this.fecha = fecha;
    this.areaId = areaId;
    this.procesoId = procesoId;
    this.observadoId = observadoId;
    this.generoId = generoId;
    this.turnoId = turnoId;
    this.jornadaId = jornadaId;
    this.efectoId = efectoId;
    this.clasificacionId = clasificacionId;
    this.actividadId = actividadId;
    this.riesgoId = riesgoId;
    this.causaBasicaId = causaBasicaId;
    this.causaInmediataId = causaInmediataId;
    this.parteCuerpoId = parteCuerpoId;
    this.descripcion = descripcion;
    this.actividad = actividad;
    this.area = area;
    this.causaBasica = causaBasica;
    this.causaInmediata = causaInmediata;
    this.parteCuerpo = parteCuerpo;
    this.clasificacion = clasificacion;
    this.riesgo = riesgo;
    this.efecto = efecto;
    this.genero = genero;
    this.jornada = jornada;
    this.proceso = proceso;
    this.turno = turno;
  }
}
