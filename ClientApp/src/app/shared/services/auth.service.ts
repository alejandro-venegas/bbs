import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Rol } from "../models/rol.model";
import { environment } from "../../../environments/environment";
import { Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  private base_url = environment.base_url + "roles";
  rolId = 1;
  rol: Rol;
  rolChangedSubject = new Subject<boolean>();
  constructor(private http: HttpClient) {}

  getCurrentUserRol() {
    return this.http.get<Rol>(
      this.base_url + "/" + (localStorage.getItem("rolId") || this.rolId)
    );
  }
}
