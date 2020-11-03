import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Rol } from '../models/rol.model';
import { environment } from '../../../environments/environment';
import { BehaviorSubject, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private base_url = environment.base_url + 'auth';
  rol: Rol;
  rolChangedSubject = new BehaviorSubject<any>(null);
  constructor(private http: HttpClient, private router: Router) {}

  getCurrentUser() {
    return this.http.get<any>(this.base_url);
  }
  logIn(username: string, password: string) {
    return this.http
      .post<any>(this.base_url, { username, password })
      .pipe(
        tap((res) => {
          localStorage.setItem('token', res.token);
        })
      );
  }

  logOut() {
    localStorage.clear();
    this.router.navigate(['login']);
  }
}
