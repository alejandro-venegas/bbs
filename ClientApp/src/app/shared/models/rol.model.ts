export class Rol {
    public id: number;
    public nombreRol: string;
    public descripcionRol: string;

    constructor(id: number, nombreRol: string, descripcionRol: string) {
        this.id = id;
        this.nombreRol = nombreRol;
        this.descripcionRol = descripcionRol;
    }
}
