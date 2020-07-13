import { Component, Inject, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { ColaboradoresService } from "../../../shared/services/colaboradores.service";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { DepartamentosService } from "../departamentos.service";
import { Colaborador } from "../../../shared/models/colaborador.model";

@Component({
  selector: "app-nuevo-departamento-dialog",
  templateUrl: "./nuevo-departamento-dialog.component.html",
  styleUrls: ["./nuevo-departamento-dialog.component.css"],
})
export class NuevoDepartamentoDialogComponent implements OnInit {
  isEdit = false;
  colaboradores: Colaborador[] = [];
  departamentoForm = this.fb.group({
    nombre: ["", [Validators.required, Validators.maxLength(35)]],
    gerenteId: ["", Validators.required],
  });
  constructor(
    private fb: FormBuilder,
    private colaboradoresService: ColaboradoresService,
    private departamentosService: DepartamentosService,
    private dialogRef: MatDialogRef<NuevoDepartamentoDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    if (this.data && this.data.departamento) {
      const { nombre, gerenteId } = this.data.departamento;
      this.isEdit = true;
      let value: any = { nombre };
      if (gerenteId) {
        value.gerenteId = gerenteId;
      }
      this.departamentoForm.patchValue(value);
    }
    this.getColaboradores();
  }

  get nombre() {
    return this.departamentoForm.get("nombre");
  }
  get gerenteId() {
    return this.departamentoForm.get("gerenteId");
  }

  getColaboradores() {
    this.colaboradoresService.getColaboradores().subscribe((res) => {
      this.colaboradores = res;
    });
  }
  submitForm() {
    if (this.departamentoForm.valid) {
      const value = this.departamentoForm.value;
      if (this.isEdit) {
        value.id = this.data.departamento.id;
        this.departamentosService.updateDepartamento(value).subscribe((res) => {
          if (res.status === 202) {
            this.dialogRef.close(true);
          }
        });
      } else {
        this.departamentosService.postDepartamento(value).subscribe((res) => {
          if (res.status === 201) {
            this.dialogRef.close(true);
          }
        });
      }
    } else {
      this.departamentoForm.markAllAsTouched();
    }
  }
}
