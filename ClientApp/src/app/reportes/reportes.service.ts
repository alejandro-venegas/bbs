import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Incidente } from '../shared/models/incidente.model';
import { CasiIncidenteComponent } from './casi-incidente/casi-incidente.component';
import { CasiIncidente } from '../shared/models/casiIncidente.model';
import { Bbs } from '../shared/models/bbs.model';

@Injectable({
  providedIn: 'root',
})
export class ReportesService {
  baseUrl = environment.base_url;
  constructor(private http: HttpClient) {}

  guardarIncidente(incidente: Incidente) {
    return this.http.post(this.baseUrl + 'incidentes/new', incidente, {
      observe: 'response',
    });
  }

  guardarCasiIncidente(casiIncidente: CasiIncidente) {
    return this.http.post(this.baseUrl + 'casiincidentes/new', casiIncidente, {
      observe: 'response',
    });
  }

  guardarBbs(bbs: Bbs) {
    return this.http.post(this.baseUrl + 'bbs/new', bbs, {
      observe: 'response',
    });
  }

  updateBbs(bbs: Bbs) {
    return this.http.post(this.baseUrl + 'bbs/update', bbs, {
      observe: 'response',
    });
  }

  guardarCondicionInsegura(condicionInsegura: any) {
    return this.http.post(
      this.baseUrl + 'condicioninseguras/new',
      condicionInsegura,
      { observe: 'response' }
    );
  }

  getIncidentes() {
    return this.http.get<any[]>(this.baseUrl + 'incidentes');
  }
  getCasiIncidentes() {
    return this.http.get<any[]>(this.baseUrl + 'casiincidentes');
  }
  getBbs(id: number) {
    return this.http.get<Bbs>(this.baseUrl + 'bbs?id=' + id);
  }
  getBbss() {
    return this.http.get<any[]>(this.baseUrl + 'bbs');
  }
  getCondicionesInseguras() {
    return this.http.get<any[]>(this.baseUrl + 'condicioninseguras');
  }
}
