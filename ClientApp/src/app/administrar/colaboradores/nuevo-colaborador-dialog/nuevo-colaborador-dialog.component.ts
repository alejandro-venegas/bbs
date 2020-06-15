import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ColaboradoresService } from '../../../shared/services/colaboradores.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Departamento } from '../../../shared/models/departamento.model';
import { DepartamentosService } from '../../departamentos/departamentos.service';

@Component({
  selector: 'app-nuevo-colaborador-dialog',
  templateUrl: './nuevo-colaborador-dialog.component.html',
  styleUrls: ['./nuevo-colaborador-dialog.component.css'],
})
export class NuevoColaboradorDialogComponent implements OnInit {
  isEdit = false;
  departamentos: Departamento[] = [];
  colaboradorForm = this.fb.group({
    nombre: [''],
    apellido: [''],
    puesto: [''],
    departamentoId: [''],
  });
  constructor(
    private fb: FormBuilder,
    private colaboradoresService: ColaboradoresService,
    private dialogRef: MatDialogRef<NuevoColaboradorDialogComponent>,
    private departamentosService: DepartamentosService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.getDepartamentos();
    if (this.data && this.data.colaborador) {
      this.isEdit = true;
      let data: any = {
        nombre: this.data.colaborador.nombre,
        apellido: this.data.colaborador.apellido,
        puesto: this.data.colaborador.puesto,
      };
      if (this.data.colaborador.departamentoId) {
        data.departamentoId = this.data.colaborador.departamentoId;
      }
      this.colaboradorForm.patchValue(data);
    }
  }

  getDepartamentos() {
    this.departamentosService
      .getDepartamentos()
      .subscribe((res) => (this.departamentos = res));
  }

  submitForm() {
    const value = this.colaboradorForm.value;

    if (this.isEdit) {
      value.id = this.data.colaborador.id;
      this.colaboradoresService.updateColaborador(value).subscribe((res) => {
        if (res.status === 202) {
          this.dialogRef.close(true);
        }
      });
    } else {
      this.colaboradoresService.postColaborador(value).subscribe((res) => {
        if (res.status === 201) {
          this.dialogRef.close(true);
        }
      });
    }
  }
}
