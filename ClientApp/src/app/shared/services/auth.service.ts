import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Rol } from "../models/rol.model";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  private base_url = environment.base_url + "roles";
  rolId = 3;
  rol: Rol;
  constructor(private http: HttpClient) {}

  getCurrentUserRol() {
    return this.http.get<Rol>(this.base_url + "/" + this.rolId);
  }
}
