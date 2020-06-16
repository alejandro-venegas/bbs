import { SelectNode } from '../../mantenimiento/formularios/tree-datasource';

export class Incidente {
  public id: number;
  public fechaIncidente: Date;
  public areaId: number;
  public procesoId: number;
  public observado;
  public generoId: number;
  public turnoId: number;
  public jornadaId: number;
  public efectoId: number;
  public clasificacionId: number;
  public actividadId: number;
  public riesgoId: number;
  public supervisorId: number;
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
  public supervisor: SelectNode;
  public riesgo: SelectNode;
  public efecto: SelectNode;
  public genero: SelectNode;
  public jornada: SelectNode;
  public proceso: SelectNode;
  public turno: SelectNode;

  constructor(
    id: number,
    fechaIncidente: Date,
    areaId: number,
    procesoId: number,
    observado,
    generoId: number,
    turnoId: number,
    jornadaId: number,
    efectoId: number,
    clasificacionId: number,
    actividadId: number,
    riesgoId: number,
    supervisorId: number,
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
    supervisor?: SelectNode,
    riesgo?: SelectNode,
    efecto?: SelectNode,
    genero?: SelectNode,
    jornada?: SelectNode,
    proceso?: SelectNode,
    turno?: SelectNode
  ) {
    this.id = id;
    this.fechaIncidente = fechaIncidente;
    this.areaId = areaId;
    this.procesoId = procesoId;
    this.observado = observado;
    this.generoId = generoId;
    this.turnoId = turnoId;
    this.jornadaId = jornadaId;
    this.efectoId = efectoId;
    this.clasificacionId = clasificacionId;
    this.actividadId = actividadId;
    this.riesgoId = riesgoId;
    this.supervisorId = supervisorId;
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
    this.supervisor = supervisor;
    this.riesgo = riesgo;
    this.efecto = efecto;
    this.genero = genero;
    this.jornada = jornada;
    this.proceso = proceso;
    this.turno = turno;
  }
}
