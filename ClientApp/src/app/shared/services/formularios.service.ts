import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { SelectNode } from '../../mantenimiento/formularios/tree-datasource';
const baseUrl = environment.base_url + 'formularios';
@Injectable({
  providedIn: 'root',
})
export class FormulariosService {
  constructor(private http: HttpClient) {}

  getSelectOptions() {
    return this.http.get<SelectNode[]>(baseUrl);
  }

  insertSelect(select: SelectNode) {
    return this.http.post<any>(baseUrl + '/new', select, {
      observe: 'response',
    });
  }
  deleteSelect(select: SelectNode) {
    return this.http.delete<any>(
      baseUrl + `?optionId=${select.optionId}&selectId=${select.selectId}`,
      {
        observe: 'response',
      }
    );
  }
}
