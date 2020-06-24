import { Component, OnInit } from '@angular/core';
import { FormulariosService } from '../../shared/services/formularios.service';

import { FormBuilder, Validators } from '@angular/forms';
import { ReportesService } from '../reportes.service';
import { Colaborador } from '../../shared/models/colaborador.model';
import { ColaboradoresService } from '../../shared/services/colaboradores.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-bbs',
  templateUrl: './bbs.component.html',
  styleUrls: ['./bbs.component.css'],
})
export class BbsComponent implements OnInit {
  opciones: any;
  colaboradores: Colaborador[] = [];
  id: number;
  bbsForm = this.fb.group({
    fecha: ['', Validators.required],
    areaId: ['', Validators.required],
    observadorId: ['', Validators.required],
    procesoId: ['', Validators.required],
    comportamientoId: ['', Validators.required],
    tipoObservadoId: ['', Validators.required],
    tipoComportamientoId: ['', Validators.required],
  });
  constructor(
    private formulariosService: FormulariosService,
    private colaboradoresService: ColaboradoresService,
    private fb: FormBuilder,
    private reportesService: ReportesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  get fecha() {
    return this.bbsForm.get('fecha');
  }
  get areaId() {
    return this.bbsForm.get('areaId');
  }
  get observadorId() {
    return this.bbsForm.get('observadorId');
  }
  get procesoId() {
    return this.bbsForm.get('procesoId');
  }
  get comportamientoId() {
    return this.bbsForm.get('comportamientoId');
  }
  get tipoObservadoId() {
    return this.bbsForm.get('tipoObservadoId');
  }
  get tipoComportamientoId() {
    return this.bbsForm.get('tipoComportamientoId');
  }

  ngOnInit(): void {
    this.getOpcionesSelect();
    this.getGerentes();
    this.id = this.route.snapshot.queryParams.id;
    if (this.id) {
      this.reportesService.getBbs(this.id).subscribe((res) => {
        this.bbsForm.patchValue(res);
      });
    }
  }

  getGerentes() {
    this.colaboradoresService
      .getColaboradores()
      .subscribe((res) => (this.colaboradores = res));
  }

  submitForm() {
    if (this.bbsForm.valid) {
      const value = this.bbsForm.value;
      if (this.id) {
        value.id = this.id;
        this.reportesService.updateBbs(value).subscribe((res) => {
          if (res.status === 202) {
            this.router.navigate(['../lista'], { relativeTo: this.route });
          }
        });
      } else {
        this.reportesService.guardarBbs(value).subscribe((res) => {
          if (res.status === 201) {
            this.router.navigate(['../lista'], { relativeTo: this.route });
          }
        });
      }
    } else {
      this.bbsForm.markAllAsTouched();
    }
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
