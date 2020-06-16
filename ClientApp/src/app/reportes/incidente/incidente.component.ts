import { Component, OnInit } from '@angular/core';
import { FormulariosService } from '../../shared/services/formularios.service';
import { DepartamentosService } from '../../administrar/departamentos/departamentos.service';
import { Colaborador } from '../../shared/models/colaborador.model';
import { FormBuilder } from '@angular/forms';
import { ReportesService } from '../reportes.service';

@Component({
  selector: 'app-incidente',
  templateUrl: './incidente.component.html',
  styleUrls: ['./incidente.component.css'],
})
export class IncidenteComponent implements OnInit {
  opciones: any;
  gerentes: Colaborador[] = [];
  incidenteForm = this.fb.group({
    fechaIncidente: [''],
    areaId: [''],
    procesoId: [''],
    observado: [''],
    generoId: [''],
    turnoId: [''],
    jornadaId: [''],
    efectoId: [''],
    clasificacionId: [''],
    causaBasicaId: [''],
    causaInmediataId: [''],
    parteCuerpoId: [''],
    actividadId: [''],
    descripcion: [''],
    supervisorId: [''],
    riesgoId: [''],
  });
  constructor(
    private formulariosService: FormulariosService,
    private departamentosService: DepartamentosService,
    private fb: FormBuilder,
    private reportesService: ReportesService
  ) {}
  ngOnInit(): void {
    this.getOpcionesSelect();
    this.getGerentes();
  }

  getGerentes() {
    this.departamentosService
      .getGerentes()
      .subscribe((res) => (this.gerentes = res));
  }

  submitForm() {
    const value = this.incidenteForm.value;
    console.log(value);
    this.reportesService
      .guardarIncidente(value)
      .subscribe((res) => console.log(res));
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
