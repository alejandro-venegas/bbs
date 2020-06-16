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

  categorizeOptions(allOptions: SelectNode[]) {
    const optionsByGroup = {
      actividades: [],
      areas: [],
      casualidades: [],
      causaBasicas: [],
      causaInmediatas: [],
      clasificaciones: [],
      comportamientos: [],
      efectos: [],
      factorRiesgos: [],
      generos: [],
      indicadorRiesgos: [],
      jornadas: [],
      observados: [],
      parteCuerpos: [],
      procesos: [],
      riesgos: [],
      tipoComportamientos: [],
      tipoObservados: [],
      turnos: [],
    };
    for (const opcion of allOptions) {
      switch (parseInt(opcion.selectId)) {
        case 1:
          optionsByGroup.actividades.push(opcion);
          break;
        case 2:
          optionsByGroup.areas.push(opcion);
          break;
        case 3:
          optionsByGroup.casualidades.push(opcion);
          break;
        case 4:
          optionsByGroup.causaBasicas.push(opcion);
          break;
        case 5:
          optionsByGroup.causaInmediatas.push(opcion);
          break;
        case 6:
          optionsByGroup.clasificaciones.push(opcion);
          break;
        case 7:
          optionsByGroup.comportamientos.push(opcion);
          break;
        case 8:
          optionsByGroup.efectos.push(opcion);
          break;
        case 9:
          optionsByGroup.factorRiesgos.push(opcion);
          break;
        case 10:
          optionsByGroup.generos.push(opcion);
          break;
        case 11:
          optionsByGroup.indicadorRiesgos.push(opcion);
          break;
        case 12:
          optionsByGroup.jornadas.push(opcion);
          break;
        case 13:
          optionsByGroup.observados.push(opcion);
          break;
        case 14:
          optionsByGroup.parteCuerpos.push(opcion);
          break;
        case 15:
          optionsByGroup.procesos.push(opcion);
          break;
        case 16:
          optionsByGroup.riesgos.push(opcion);
          break;
        case 17:
          optionsByGroup.tipoComportamientos.push(opcion);
          break;
        case 18:
          optionsByGroup.tipoObservados.push(opcion);
          break;
        case 19:
          optionsByGroup.turnos.push(opcion);
          break;
      }
    }

    return optionsByGroup;
  }
}
