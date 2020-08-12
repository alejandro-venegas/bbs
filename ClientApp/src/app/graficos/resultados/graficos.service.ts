import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class GraficosService {
  baseUrl = environment.base_url;
  constructor(private http: HttpClient) {}

  getGraficas(
    tipoGraficas: string,
    propiedad: string,
    startDate: Date,
    endDate: Date
  ) {
    return this.http.get<any[]>(
      this.baseUrl +
        "graficas?tipoGraficas=" +
        tipoGraficas +
        "&propiedad=" +
        propiedad +
        "&startDate=" +
        startDate +
        "&endDate=" +
        endDate
    );
  }
}
