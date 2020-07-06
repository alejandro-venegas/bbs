export class Rol {
  public id: number;
  public nombre: string;
  public descripcion: string;
  public rolVistas?: any[];

  constructor(id: number, nombre: string, descripcion: string) {
    this.id = id;
    this.nombre = nombre;
    this.descripcion = descripcion;
  }
}
