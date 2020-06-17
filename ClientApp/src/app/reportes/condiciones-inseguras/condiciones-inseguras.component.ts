import { Component, OnInit } from '@angular/core';
import { Colaborador } from '../../shared/models/colaborador.model';
import { FormulariosService } from '../../shared/services/formularios.service';
import { DepartamentosService } from '../../administrar/departamentos/departamentos.service';
import { FormBuilder } from '@angular/forms';
import { ReportesService } from '../reportes.service';

@Component({
  selector: 'app-condiciones-inseguras',
  templateUrl: './condiciones-inseguras.component.html',
  styleUrls: ['./condiciones-inseguras.component.css'],
})
export class CondicionesInsegurasComponent implements OnInit {
  opciones: any;
  gerentes: Colaborador[] = [];
  condicionInseguraForm = this.fb.group({
    fechaCondicion: [''],
    supervisorId: [''],
    procesoId: [''],
    areaId: [''],
    indicadorRiesgoId: [''],
    factorRiesgoId: [''],
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
    const value = this.condicionInseguraForm.value;
    this.reportesService
      .guardarCondicionInsegura(value)
      .subscribe((res) => console.log(res));
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
