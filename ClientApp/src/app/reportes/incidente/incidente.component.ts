import { Component, OnInit } from "@angular/core";
import { FormulariosService } from "../../shared/services/formularios.service";
import { DepartamentosService } from "../../administrar/departamentos/departamentos.service";
import { Colaborador } from "../../shared/models/colaborador.model";
import { FormBuilder, Validators } from "@angular/forms";
import { ReportesService } from "../reportes.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-incidente",
  templateUrl: "./incidente.component.html",
  styleUrls: ["./incidente.component.css"],
})
export class IncidenteComponent implements OnInit {
  editable: boolean;
  opciones: any;
  maxDate: Date;
  id: number;
  gerentes: Colaborador[] = [];
  incidenteForm = this.fb.group({
    fecha: ["", Validators.required],
    areaId: ["", Validators.required],
    procesoId: ["", Validators.required],
    observado: ["", [Validators.required, Validators.maxLength(70)]],
    generoId: ["", Validators.required],
    turnoId: ["", Validators.required],
    jornadaId: ["", Validators.required],
    efectoId: ["", Validators.required],
    clasificacionId: ["", Validators.required],
    causaBasicaId: ["", Validators.required],
    causaInmediataId: ["", Validators.required],
    parteCuerpoId: ["", Validators.required],
    actividadId: ["", Validators.required],
    descripcion: ["", [Validators.required, Validators.maxLength(100)]],
    riesgoId: ["", Validators.required],
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
    return this.incidenteForm.get("fecha");
  }
  get areaId() {
    return this.incidenteForm.get("areaId");
  }
  get procesoId() {
    return this.incidenteForm.get("procesoId");
  }
  get observado() {
    return this.incidenteForm.get("observado");
  }
  get generoId() {
    return this.incidenteForm.get("generoId");
  }
  get turnoId() {
    return this.incidenteForm.get("turnoId");
  }
  get jornadaId() {
    return this.incidenteForm.get("jornadaId");
  }
  get efectoId() {
    return this.incidenteForm.get("efectoId");
  }
  get clasificacionId() {
    return this.incidenteForm.get("clasificacionId");
  }
  get causaBasicaId() {
    return this.incidenteForm.get("causaBasicaId");
  }
  get causaInmediataId() {
    return this.incidenteForm.get("causaInmediataId");
  }
  get parteCuerpoId() {
    return this.incidenteForm.get("parteCuerpoId");
  }
  get actividadId() {
    return this.incidenteForm.get("actividadId");
  }
  get descripcion() {
    return this.incidenteForm.get("descripcion");
  }

  get riesgoId() {
    return this.incidenteForm.get("riesgoId");
  }

  ngOnInit(): void {
    this.maxDate = new Date();
    this.route.data.subscribe((data) => {
      this.editable = data.permission;
    });
    this.getOpcionesSelect();
    this.getGerentes();
    this.id = this.route.snapshot.queryParams.id;
    if (this.id) {
      this.reportesService.getIncidente(this.id).subscribe((res) => {
        this.incidenteForm.patchValue(res);
      });
    }
  }

  getGerentes() {
    this.departamentosService
      .getGerentes()
      .subscribe((res) => (this.gerentes = res));
  }

  submitForm() {
    if (this.incidenteForm.valid) {
      const value = this.incidenteForm.value;

      if (this.id) {
        value.id = this.id;
        this.reportesService.updateIncidente(value).subscribe((res) => {
          if (res.status === 202) {
            this.router.navigate(["../lista"], { relativeTo: this.route });
          }
        });
      } else {
        this.reportesService.guardarIncidente(value).subscribe((res) => {
          if (res.status === 201) {
            this.router.navigate(["../lista"], { relativeTo: this.route });
          }
        });
      }
    } else {
      this.incidenteForm.markAllAsTouched();
    }
  }

  getOpcionesSelect() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      this.opciones = this.formulariosService.categorizeOptions(res);
    });
  }
}
