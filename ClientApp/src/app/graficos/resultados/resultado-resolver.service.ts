import { Injectable } from "@angular/core";
import {
  ActivatedRouteSnapshot,
  Resolve,
  Router,
  RouterStateSnapshot,
} from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { GraficosService } from "./graficos.service";

@Injectable()
export class ResultadoResolver implements Resolve<any> {
  constructor(
    private graficosService: GraficosService,
    private router: Router
  ) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> | Promise<any> | any {
    const tipoGrafica = route.queryParams.tipoGrafica;
    let propiedades = route.queryParams.propiedades;
    propiedades = propiedades && propiedades.split(",");

    if (tipoGrafica && propiedades) {
      return this.graficosService
        .getGraficas(tipoGrafica, propiedades[0].toLowerCase())
        .pipe(
          map((res) => {
            return res;
          })
        );
    }
    this.router.navigate(["graficos/filtros"]);
    return null;
  }
}
