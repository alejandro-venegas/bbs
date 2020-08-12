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
    const tiposGraficas = route.queryParams.tiposGraficas;
    let propiedades = route.queryParams.propiedades;
    const startDate = route.queryParams.startDate;
    const endDate = route.queryParams.endDate;

    propiedades = propiedades && propiedades.split(",");

    if (tiposGraficas && propiedades) {
      return this.graficosService
        .getGraficas(
          tiposGraficas,
          propiedades[0].toLowerCase(),
          startDate,
          endDate
        )
        .pipe(
          map((res) => {
            console.log(res);
            return res;
          })
        );
    }
    this.router.navigate(["graficos/filtros"]);
    return null;
  }
}
