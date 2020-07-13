import { Component, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { Colaborador } from "../../shared/models/colaborador.model";
import { FormulariosService } from "../../shared/services/formularios.service";
import { DepartamentosService } from "../../administrar/departamentos/departamentos.service";
import { ReportesService } from "../reportes.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-casi-incidente",
  templateUrl: "./casi-incidente.component.html",
  styleUrls: ["./casi-incidente.component.css"],
})
export class CasiIncidenteComponent implements OnInit {
  editable: boolean;
  id: number;
  opciones: any;
  maxDate: Date;
  gerentes: Colaborador[] = [];
  casiIncidenteForm = this.fb.group({
    fecha: ["", Validators.required],
    areaId: ["", Validators.required],
    procesoId: ["", Validators.required],
    observado: ["", [Validators.required, Validators.maxLength(70)]],
    casualidadId: ["", Validators.required],
    turnoId: ["", Validators.required],
    jornadaId: ["", Validators.required],
    generoId: ["", Validators.required],
    descripcion: ["", [Validators.required, Validators.maxLength(100)]],
    supervisorId: ["", Validators.required],
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
    return this.casiIncidenteForm.get("fecha");
  }
  get areaId() {
    return this.casiIncidenteForm.get("areaId");
  }
  get procesoId() {
    return this.casiIncidenteForm.get("procesoId");
  }
  get observado() {
    return this.casiIncidenteForm.get("observado");
  }
  get generoId() {
    return this.casiIncidenteForm.get("generoId");
  }
  get turnoId() {
    return this.casiIncidenteForm.get("turnoId");
  }
  get jornadaId() {
    return this.casiIncidenteForm.get("jornadaId");
  }
  get casualidadId() {
    return this.casiIncidenteForm.get("casualidadId");
  }

  get descripcion() {
    return this.casiIncidenteForm.get("descripcion");
  }
  get supervisorId() {
    return this.casiIncidenteForm.get("supervisorId");
  }
  get riesgoId() {
    return this.casiIncidenteForm.get("riesgoId");
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
      this.reportesService.getCasiIncidente(this.id).subscribe((res) => {
        this.casiIncidenteForm.patchValue(res);
      });
    }
  }

  getColaboradores() {
    this.departamentosService
      .getGerentes()
      .subscribe((res) => (this.gerentes = res));
  }

  submitForm() {
    if (this.casiIncidenteForm.valid) {
      const value = this.casiIncidenteForm.value;
      if (this.id) {
        value.id = this.id;
        this.reportesService.updateCasiIncidente(value).subscribe((res) => {
          if (res.status === 202) {
            this.router.navigate(["../lista"], { relativeTo: this.route });
          }
        });
      } else {
        this.reportesService.guardarCasiIncidente(value).subscribe((res) => {
          if (res.status === 201) {
            this.router.navigate(["../lista"], { relativeTo: this.route });
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
