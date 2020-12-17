import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Colaborador } from '../../shared/models/colaborador.model';
import { FormulariosService } from '../../shared/services/formularios.service';
import { DepartamentosService } from '../../administrar/departamentos/departamentos.service';
import { ReportesService } from '../reportes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ColaboradoresService } from '../../shared/services/colaboradores.service';

@Component({
  selector: 'app-casi-incidente',
  templateUrl: './casi-incidente.component.html',
  styleUrls: ['./casi-incidente.component.css'],
})
export class CasiIncidenteComponent implements OnInit {
  editable: boolean;
  id: number;
  opciones: any;
  maxDate: Date;
  gerentes: Colaborador[] = [];
  colaboradores: Colaborador[] = [];
  casiIncidenteForm = this.fb.group({
    fecha: ['', Validators.required],
    areaId: ['', Validators.required],
    procesoId: ['', Validators.required],
    observadoId: ['', Validators.required],
    casualidadId: ['', Validators.required],
    turnoId: ['', Validators.required],
    jornadaId: ['', Validators.required],
    generoId: ['', Validators.required],
    descripcion: ['', [Validators.required, Validators.maxLength(100)]],

    riesgoId: ['', Validators.required],
  });
  constructor(
    private formulariosService: FormulariosService,
    private departamentosService: DepartamentosService,
    private fb: FormBuilder,
    private reportesService: ReportesService,
    private route: ActivatedRoute,
    private router: Router,
    private colaboradoresService: ColaboradoresService
  ) {}
  get fecha() {
    return this.casiIncidenteForm.get('fecha');
  }
  get areaId() {
    return this.casiIncidenteForm.get('areaId');
  }
  get procesoId() {
    return this.casiIncidenteForm.get('procesoId');
  }
  get observado() {
    return this.casiIncidenteForm.get('observadoId');
  }
  get generoId() {
    return this.casiIncidenteForm.get('generoId');
  }
  get turnoId() {
    return this.casiIncidenteForm.get('turnoId');
  }
  get jornadaId() {
    return this.casiIncidenteForm.get('jornadaId');
  }
  get casualidadId() {
    return this.casiIncidenteForm.get('casualidadId');
  }

  get descripcion() {
    return this.casiIncidenteForm.get('descripcion');
  }

  get riesgoId() {
    return this.casiIncidenteForm.get('riesgoId');
  }

  ngOnInit(): void {
    this.maxDate = new Date();
    this.route.data.subscribe((data) => {
      this.editable = data.permission;
    });
    this.getOpcionesSelect();
    this.getGerentes();
    this.getColaboradores();
    this.id = this.route.snapshot.queryParams.id;
    if (this.id) {
      this.reportesService.getCasiIncidente(this.id).subscribe((res) => {
        this.casiIncidenteForm.patchValue(res);
      });
    }
  }

  getGerentes() {
    this.departamentosService
      .getGerentes()
      .subscribe((res) => (this.gerentes = res));
  }

  getColaboradores() {
    this.colaboradoresService
      .getColaboradores()
      .subscribe((res) => (this.colaboradores = res));
  }

  submitForm() {
    if (this.casiIncidenteForm.valid) {
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
          if (res.status === 201) {
            this.router.navigate(['../lista'], { relativeTo: this.route });
          }
        });
      }
    } else {
      this.casiIncidenteForm.markAllAsTouched();
    }
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
