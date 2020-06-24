import { Component, Inject, OnInit } from '@angular/core';
import { RolesService } from '../roles.service';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { VistasService } from '../vistas.service';

@Component({
  selector: 'app-nuevo-rol-dialog',
  templateUrl: './nuevo-rol-dialog.component.html',
  styleUrls: ['./nuevo-rol-dialog.component.css'],
})
export class NuevoRolDialogComponent implements OnInit {
  isEdit = false;
  vistasArray: any = [];
  rolForm = this.fb.group({
    nombre: ['', [Validators.required, Validators.maxLength(30)]],
    descripcion: ['', [Validators.required, Validators.maxLength(50)]],
  });
  vistas: any = [];

  constructor(
    private rolesService: RolesService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<NuevoRolDialogComponent>,
    private vistasService: VistasService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
  get nombre() {
    return this.rolForm.get('nombre');
  }

  get descripcion() {
    return this.rolForm.get('descripcion');
  }

  ngOnInit() {
    if (this.data && this.data.rol) {
      this.isEdit = true;
      this.vistas = this.data.rol.rolVistas.map((rolVista) => rolVista.vistaId);
      this.rolForm.setValue({
        nombre: this.data.rol.nombre,
        descripcion: this.data.rol.descripcion,
      });
    }
    this.getVistas();
  }

  isViewSelected(id: number): boolean {
    if (this.vistas.find((vista) => vista === id)) {
      return true;
    }
    return false;
  }

  getVistas() {
    this.vistasService.getVistas().subscribe((res) => {
      this.vistasArray = res;
    });
  }

  submitForm() {
    if (this.rolForm.valid) {
      const value = this.rolForm.value;

      value.vistas = this.vistas;
      if (this.isEdit) {
        value.id = this.data.rol && this.data.rol.id;
        this.rolesService.updateRole(value).subscribe((res) => {
          if (res.status === 202) {
            this.dialogRef.close(true);
          }
        });
      } else {
        this.rolesService.postRole(value).subscribe((res) => {
          if (res.status === 201) {
            this.dialogRef.close(true);
          }
        });
      }
    } else {
      this.rolForm.markAllAsTouched();
    }
  }

  onSelectVista(id: number, isChecked: boolean) {
    if (isChecked) {
      this.vistas.push(id);
    } else {
      this.vistas = this.vistas.filter((vista) => vista !== id);
    }
  }
}
