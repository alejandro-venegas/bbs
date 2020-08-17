import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class BitacoraService {
  baseUrl = environment.base_url + "bitacora";
  constructor(private http: HttpClient) {}
  getBitacora() {
    return this.http.get<any[]>(this.baseUrl);
  }
}
