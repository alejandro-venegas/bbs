import { Injectable } from "@angular/core";
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from "@angular/router";
import { Observable } from "rxjs";
import { AuthService } from "../services/auth.service";
import { map, tap } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    return this.authService.getCurrentUserRol().pipe(
      map((res) => {
        if (res) {
          const permittedViews = res.rolVistas.map((rolVista) =>
            rolVista.vista.nombre.toLowerCase()
          );
          if (permittedViews.find((view) => view === state.url.split("/")[1])) {
            return true;
          }
        }
        return this.router.parseUrl("forbidden");
      })
    );
  }
}