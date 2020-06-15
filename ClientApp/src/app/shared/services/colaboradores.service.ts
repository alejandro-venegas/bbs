import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Colaborador } from '../models/colaborador.model';

@Injectable({
  providedIn: 'root',
})
export class ColaboradoresService {
  private base_url = environment.base_url + 'colaboradores';
  constructor(private http: HttpClient) {}

  postColaborador(colaborador: Colaborador) {
    const url = this.base_url + '/new';
    return this.http.post<any>(url, colaborador, { observe: 'response' });
  }

  getColaboradores() {
    return this.http.get<Colaborador[]>(this.base_url);
  }

  updateColaborador(colaborador: Colaborador) {
    const url = this.base_url + '/update';
    return this.http.post<any>(url, colaborador, { observe: 'response' });
  }
  deleteColaborador(id: number) {
    return this.http.delete<any>(this.base_url + '?id=' + id, {
      observe: 'response',
    });
  }
}
