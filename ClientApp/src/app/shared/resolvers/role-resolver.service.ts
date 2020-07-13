import { Injectable } from "@angular/core";
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot,
} from "@angular/router";
import { Observable } from "rxjs";
import { AuthService } from "../services/auth.service";
import { map } from "rxjs/operators";

@Injectable()
export class RoleResolver implements Resolve<any> {
  constructor(private authService: AuthService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> | Promise<any> | any {
    return this.authService.getCurrentUserRol().pipe(
      map((res) => {
        if (res) {
          const thisView = res.rolVistas.find(
            (view) =>
              view.vista.url === state.url.substr(0, view.vista.url.length)
          );
          return thisView.escritura;
        }
        return null;
      })
    );
  }
}
