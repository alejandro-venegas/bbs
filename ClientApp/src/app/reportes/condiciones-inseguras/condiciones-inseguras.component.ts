import { Component, OnInit } from '@angular/core';
import { Colaborador } from '../../shared/models/colaborador.model';
import { FormulariosService } from '../../shared/services/formularios.service';
import { DepartamentosService } from '../../administrar/departamentos/departamentos.service';
import { FormBuilder, Validators } from '@angular/forms';
import { ReportesService } from '../reportes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ColaboradoresService } from '../../shared/services/colaboradores.service';

@Component({
  selector: 'app-condiciones-inseguras',
  templateUrl: './condiciones-inseguras.component.html',
  styleUrls: ['./condiciones-inseguras.component.css'],
})
export class CondicionesInsegurasComponent implements OnInit {
  editable: boolean;
  maxDate: Date;
  id: number;
  opciones: any;
  subcategorias: any[] = [];
  condicionInseguraForm = this.fb.group({
    fecha: ['', Validators.required],
    areaId: ['', Validators.required],
    categoriaId: ['', Validators.required],
    subcategoriaId: ['', Validators.required],
    exposicion: ['', Validators.required],
    probabilidad: ['', Validators.required],
    valorRiesgo: ['', Validators.required],
    consecuencia: ['', Validators.required],
    nivelRiesgo: ['', Validators.required],
    prioridadAtencion: ['', [Validators.required]],
    accion: ['', [Validators.required]],
    descripcion: ['', [Validators.required]],
    fechaCompromiso: ['', Validators.required],
    responsableId: ['', Validators.required],
    fechaCierre: [null],
    estatusCierre: ['', Validators.required],
  });

  colaboradores: Colaborador[] = [];
  constructor(
    private formulariosService: FormulariosService,
    private colaboradoresService: ColaboradoresService,
    private fb: FormBuilder,
    private reportesService: ReportesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  get fecha() {
    return this.condicionInseguraForm.get('fecha');
  }
  get areaId() {
    return this.condicionInseguraForm.get('areaId');
  }
  get categoriaId() {
    return this.condicionInseguraForm.get('categoriaId');
  }
  get subcategoriaId() {
    return this.condicionInseguraForm.get('subcategoriaId');
  }
  get exposicion() {
    return this.condicionInseguraForm.get('exposicion');
  }
  get probabilidad() {
    return this.condicionInseguraForm.get('probabilidad');
  }
  get valorRiesgo() {
    return this.condicionInseguraForm.get('valorRiesgo');
  }
  get nivelRiesgo() {
    return this.condicionInseguraForm.get('nivelRiesgo');
  }
  get prioridadAtencion() {
    return this.condicionInseguraForm.get('prioridadAtencion');
  }
  get accion() {
    return this.condicionInseguraForm.get('accion');
  }
  get descripcion() {
    return this.condicionInseguraForm.get('descripcion');
  }
  get fechaCompromiso() {
    return this.condicionInseguraForm.get('fechaCompromiso');
  }
  get fechaCierre() {
    return this.condicionInseguraForm.get('fechaCierre');
  }
  get estatusCierre() {
    return this.condicionInseguraForm.get('estatusCierre');
  }
  get consecuencia() {
    return this.condicionInseguraForm.get('consecuencia');
  }

  ngOnInit(): void {
    this.maxDate = new Date();
    this.route.data.subscribe((data) => {
      this.editable = data.permission;
    });
    this.getOpcionesSelect();
    this.getColaboradores();
    this.id = this.route.snapshot.queryParams.id;
    if (this.id) {
      this.reportesService.getCondicionInsegura(this.id).subscribe((res) => {
        this.condicionInseguraForm.patchValue(res);
        this.onCategoriaSelect(res.categoriaId);
      });
    }
  }

  getColaboradores() {
    this.colaboradoresService
      .getColaboradores()
      .subscribe((res) => (this.colaboradores = res));
  }

  calculateValorRiesgo() {
    if (
      this.probabilidad.value &&
      this.consecuencia.value &&
      this.exposicion.value
    ) {
      const valorRiesgo =
        +this.probabilidad.value *
        +this.consecuencia.value *
        +this.exposicion.value;
      this.valorRiesgo.setValue(valorRiesgo);
      if (valorRiesgo > 299) {
        this.nivelRiesgo.setValue('ALTO');
        this.prioridadAtencion.setValue(1);
      } else if (valorRiesgo > 100) {
        this.nivelRiesgo.setValue('MEDIO');
        this.prioridadAtencion.setValue(2);
      } else {
        this.nivelRiesgo.setValue('BAJO');
        this.prioridadAtencion.setValue(3);
      }
    }
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
        console.log(value);
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

  onCategoriaSelect(id: string) {
    const categoria =
      this.opciones &&
      this.opciones.categorias.find((cat) => cat.optionId == id);
    this.subcategorias = categoria && categoria.childOptions;
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
