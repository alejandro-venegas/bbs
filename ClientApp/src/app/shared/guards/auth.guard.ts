import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
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
    return this.authService.getCurrentUser().pipe(
      map((res) => {
        if (res) {
          const permittedViews = res.rol.rolVistas.map((value) => value.vista);
          this.authService.rolChangedSubject.next(res.rol);

          if (
            permittedViews.find(
              (view) => view.url === state.url.substr(0, view.url.length)
            )
          ) {
            return true;
          }
        }
        // this.router.navigate(['forbidden']);
        return true;
      }),
      catchError((err) => {
        console.log(err);
        // this.router.navigate(['forbidden']);
        return of(true);
      })
    );
  }
}
