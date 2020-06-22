import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Colaborador } from '../../shared/models/colaborador.model';
import { FormulariosService } from '../../shared/services/formularios.service';
import { DepartamentosService } from '../../administrar/departamentos/departamentos.service';
import { ReportesService } from '../reportes.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-casi-incidente',
  templateUrl: './casi-incidente.component.html',
  styleUrls: ['./casi-incidente.component.css'],
})
export class CasiIncidenteComponent implements OnInit {
  id: number;
  opciones: any;
  gerentes: Colaborador[] = [];
  casiIncidenteForm = this.fb.group({
    fecha: [''],
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
    private reportesService: ReportesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getOpcionesSelect();
    this.getColaboradores();
    this.id = this.route.snapshot.queryParams.id;
    if (this.id) {
      this.reportesService.getCasiIncidente(this.id).subscribe((res) => {
        this.casiIncidenteForm.patchValue(res[0]);
      });
    }
  }

  getColaboradores() {
    this.departamentosService
      .getGerentes()
      .subscribe((res) => (this.gerentes = res));
  }

  submitForm() {
    const value = this.casiIncidenteForm.value;
    if (this.id) {
      value.id = this.id;
      this.reportesService.updateCasiIncidente(value).subscribe((res) => {
        if (res.status === 202) {
          this.router.navigate(['../lista'], { relativeTo: this.route });
        }
      });
    } else {
      this.reportesService.guardarCasiIncidente(value).subscribe((res) => {
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
