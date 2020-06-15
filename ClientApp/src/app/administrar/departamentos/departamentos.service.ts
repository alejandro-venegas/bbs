import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Departamento } from '../../shared/models/departamento.model';
import { Colaborador } from '../../shared/models/colaborador.model';

@Injectable({
  providedIn: 'root',
})
export class DepartamentosService {
  baseUrl = environment.base_url + 'departamentos';
  constructor(private http: HttpClient) {}

  getDepartamentos() {
    return this.http.get<Departamento[]>(this.baseUrl);
  }
  postDepartamento(departamento: Departamento) {
    return this.http.post<any>(this.baseUrl + '/new', departamento, {
      observe: 'response',
    });
  }

  updateDepartamento(departamento: Departamento) {
    return this.http.post<any>(this.baseUrl + '/update', departamento, {
      observe: 'response',
    });
  }
  deleteDepartamento(id: number) {
    return this.http.delete<any>(this.baseUrl + '?id=' + id, {
      observe: 'response',
    });
  }
}
