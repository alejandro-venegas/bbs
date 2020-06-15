export class Colaborador {
  id?: number;
  nombre: string;
  apellido: string;
  departamentoId?: number;
  departamento?: any;

  constructor(
    nombre: string,
    apellido: string,
    departamentoId?: number,
    id?: number,
    departamento?: any
  ) {
    this.nombre = nombre;
    this.apellido = apellido;
    if (departamento) {
      this.departamento = departamento;
    }
    if (departamentoId) {
      this.departamentoId = departamentoId;
    }
    if (id) {
      this.id = id;
    }
  }
}
