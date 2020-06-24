import { Component, OnInit } from '@angular/core';
import { Colaborador } from '../../shared/models/colaborador.model';
import { FormulariosService } from '../../shared/services/formularios.service';
import { DepartamentosService } from '../../administrar/departamentos/departamentos.service';
import { FormBuilder, Validators } from '@angular/forms';
import { ReportesService } from '../reportes.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-condiciones-inseguras',
  templateUrl: './condiciones-inseguras.component.html',
  styleUrls: ['./condiciones-inseguras.component.css'],
})
export class CondicionesInsegurasComponent implements OnInit {
  id: number;
  opciones: any;
  gerentes: Colaborador[] = [];
  condicionInseguraForm = this.fb.group({
    fecha: ['', Validators.required],
    supervisorId: ['', Validators.required],
    procesoId: ['', Validators.required],
    areaId: ['', Validators.required],
    indicadorRiesgoId: ['', Validators.required],
    factorRiesgoId: ['', Validators.required],
  });
  constructor(
    private formulariosService: FormulariosService,
    private departamentosService: DepartamentosService,
    private fb: FormBuilder,
    private reportesService: ReportesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  get fecha() {
    return this.condicionInseguraForm.get('fecha');
  }
  get supervisorId() {
    return this.condicionInseguraForm.get('supervisorId');
  }
  get procesoId() {
    return this.condicionInseguraForm.get('procesoId');
  }
  get areaId() {
    return this.condicionInseguraForm.get('areaId');
  }
  get indicadorRiesgoId() {
    return this.condicionInseguraForm.get('indicadorRiesgoId');
  }
  get factorRiesgoId() {
    return this.condicionInseguraForm.get('factorRiesgoId');
  }

  ngOnInit(): void {
    this.getOpcionesSelect();
    this.getColaboradores();
    this.id = this.route.snapshot.queryParams.id;
    if (this.id) {
      this.reportesService.getCondicionInsegura(this.id).subscribe((res) => {
        this.condicionInseguraForm.patchValue(res);
      });
    }
  }

  getColaboradores() {
    this.departamentosService
      .getGerentes()
      .subscribe((res) => (this.gerentes = res));
  }

  submitForm() {
    if (this.condicionInseguraForm.valid) {
      const value = this.condicionInseguraForm.value;
      if (this.id) {
        value.id = this.id;
        this.reportesService.updateCondicionInsegura(value).subscribe((res) => {
          if (res.status === 202) {
            this.router.navigate(['../lista'], { relativeTo: this.route });
          }
        });
      } else {
        this.reportesService
          .guardarCondicionInsegura(value)
          .subscribe((res) => {
            if (res.status === 201) {
              this.router.navigate(['../lista'], { relativeTo: this.route });
            }
          });
      }
    } else {
      this.condicionInseguraForm.markAllAsTouched();
    }
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
