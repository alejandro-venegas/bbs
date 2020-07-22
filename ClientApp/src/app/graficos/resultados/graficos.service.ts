import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class GraficosService {
  baseUrl = environment.base_url;
  constructor(private http: HttpClient) {}

  getGraficas(tipoGrafica: string, propiedad: string) {
    return this.http.get<any[]>(
      this.baseUrl +
        "graficas?tipoGrafica=" +
        tipoGrafica +
        "&propiedad=" +
        propiedad
    );
  }
}
