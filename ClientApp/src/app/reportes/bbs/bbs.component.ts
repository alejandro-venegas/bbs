import { Component, OnInit } from '@angular/core';
import { FormulariosService } from '../../shared/services/formularios.service';

import { FormBuilder } from '@angular/forms';
import { ReportesService } from '../reportes.service';
import { Colaborador } from '../../shared/models/colaborador.model';
import { ColaboradoresService } from '../../shared/services/colaboradores.service';

@Component({
  selector: 'app-bbs',
  templateUrl: './bbs.component.html',
  styleUrls: ['./bbs.component.css'],
})
export class BbsComponent implements OnInit {
  opciones: any;
  colaboradores: Colaborador[] = [];
  bbsForm = this.fb.group({
    fechaBbs: [''],
    areaId: [''],
    observadorId: [''],
    descripcion: [''],
    procesoId: [''],
    comportamientoId: [''],
    tipoObservadoId: [''],
    tipoComportamientoId: [''],
  });
  constructor(
    private formulariosService: FormulariosService,
    private colaboradoresService: ColaboradoresService,
    private fb: FormBuilder,
    private reportesService: ReportesService
  ) {}

  ngOnInit(): void {
    this.getOpcionesSelect();
    this.getGerentes();
  }

  getGerentes() {
    this.colaboradoresService
      .getColaboradores()
      .subscribe((res) => (this.colaboradores = res));
  }

  submitForm() {
    const value = this.bbsForm.value;
    this.reportesService.guardarBbs(value).subscribe((res) => console.log(res));
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
