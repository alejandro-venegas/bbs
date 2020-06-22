import { Component, OnInit } from '@angular/core';
import { FormulariosService } from '../../shared/services/formularios.service';
import { DepartamentosService } from '../../administrar/departamentos/departamentos.service';
import { Colaborador } from '../../shared/models/colaborador.model';
import { FormBuilder } from '@angular/forms';
import { ReportesService } from '../reportes.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-incidente',
  templateUrl: './incidente.component.html',
  styleUrls: ['./incidente.component.css'],
})
export class IncidenteComponent implements OnInit {
  opciones: any;
  id: number;
  gerentes: Colaborador[] = [];
  incidenteForm = this.fb.group({
    fecha: [''],
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
    private reportesService: ReportesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.getOpcionesSelect();
    this.getGerentes();
    this.id = this.route.snapshot.queryParams.id;
    if (this.id) {
      this.reportesService.getIncidente(this.id).subscribe((res) => {
        this.incidenteForm.patchValue(res[0]);
      });
    }
  }

  getGerentes() {
    this.departamentosService
      .getGerentes()
      .subscribe((res) => (this.gerentes = res));
  }

  submitForm() {
    const value = this.incidenteForm.value;
    if (this.id) {
      value.id = this.id;
      this.reportesService.updateIncidente(value).subscribe((res) => {
        if (res.status === 202) {
          this.router.navigate(['../lista'], { relativeTo: this.route });
        }
      });
    } else {
      this.reportesService.guardarIncidente(value).subscribe((res) => {
        if (res.status === 200) {
          this.router.navigate(['../lista'], { relativeTo: this.route });
        }
      });
    }
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
