import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class VistasService {
  baseUrl = environment.base_url;
  constructor(private http: HttpClient) {}

  getVistas() {
    const url = this.baseUrl + 'vistas';
    return this.http.get<any>(url);
  }
}
