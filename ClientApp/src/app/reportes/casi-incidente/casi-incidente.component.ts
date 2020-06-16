import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Colaborador } from '../../shared/models/colaborador.model';
import { FormulariosService } from '../../shared/services/formularios.service';
import { DepartamentosService } from '../../administrar/departamentos/departamentos.service';
import { ReportesService } from '../reportes.service';

@Component({
  selector: 'app-casi-incidente',
  templateUrl: './casi-incidente.component.html',
  styleUrls: ['./casi-incidente.component.css'],
})
export class CasiIncidenteComponent implements OnInit {
  opciones: any;
  gerentes: Colaborador[] = [];
  casiIncidenteForm = this.fb.group({
    fechaCasiIncidente: [''],
    areaId: [''],
    procesoId: [''],
    observado: [''],
    casualidadId: [''],
    turnoId: [''],
    jornadaId: [''],
    generoId: [''],
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
    this.getColaboradores();
  }

  getColaboradores() {
    this.departamentosService
      .getGerentes()
      .subscribe((res) => (this.gerentes = res));
  }

  submitForm() {
    const value = this.casiIncidenteForm.value;
    this.reportesService
      .guardarCasiIncidente(value)
      .subscribe((res) => console.log(res));
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
