import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Rol } from './rol.model';
@Injectable({
  providedIn: 'root',
})
export class RolesService {
  base_url = environment.base_url;
  constructor(private http: HttpClient) {}

  getRoles() {
    return this.http.get<[Rol]>(this.base_url + 'roles');
  }

  postRole(data: any) {
    return this.http.post(this.base_url + 'roles/new', data, {
      observe: 'response',
    });
  }

  deleteRole(id: number) {
    return this.http.delete(this.base_url + 'roles/' + id, {
      observe: 'response',
    });
  }
  updateRole(rol: Rol) {
    return this.http.post(this.base_url + 'roles/update', rol, {
      observe: 'response',
    });
  }
}
