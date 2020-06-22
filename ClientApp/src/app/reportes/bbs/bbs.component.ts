import { Component, OnInit } from '@angular/core';
import { FormulariosService } from '../../shared/services/formularios.service';

import { FormBuilder } from '@angular/forms';
import { ReportesService } from '../reportes.service';
import { Colaborador } from '../../shared/models/colaborador.model';
import { ColaboradoresService } from '../../shared/services/colaboradores.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import DateTimeFormat = Intl.DateTimeFormat;

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
    fechaBbs: [''],
    areaId: [''],
    observadorId: [''],
    procesoId: [''],
    comportamientoId: [''],
    tipoObservadoId: [''],
    tipoComportamientoId: [''],
  });
  constructor(
    private formulariosService: FormulariosService,
    private colaboradoresService: ColaboradoresService,
    private fb: FormBuilder,
    private reportesService: ReportesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getOpcionesSelect();
    this.getGerentes();
    this.id = this.route.snapshot.queryParams.id;
  }

  getGerentes() {
    this.colaboradoresService
      .getColaboradores()
      .subscribe((res) => (this.colaboradores = res));
  }

  submitForm() {
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
        if (res.status === 200) {
          this.router.navigate(['../lista'], { relativeTo: this.route });
        }
      });
    }
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
      if (this.id) {
        this.reportesService.getBbs(this.id).subscribe((res) => {
          console.log(res);

          this.bbsForm.patchValue(res[0]);
        });
      }
    });
  }
}
