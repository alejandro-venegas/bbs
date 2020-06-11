import { Component, Inject, OnInit } from '@angular/core';
import { RolesService } from '../roles/roles.service';
import { FormArray, FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { VistasService } from '../roles/vistas.service';

@Component({
  selector: 'app-nuevo-rol-dialog',
  templateUrl: './nuevo-rol-dialog.component.html',
  styleUrls: ['./nuevo-rol-dialog.component.css'],
})
export class NuevoRolDialogComponent implements OnInit {
  isEdit = false;
  vistasArray: any = [];
  rolForm = this.fb.group({
    nombreRol: [''],
    descripcionRol: [''],
  });
  vistas: any = [];

  constructor(
    private rolesService: RolesService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<NuevoRolDialogComponent>,
    private vistasService: VistasService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit() {
    if (this.data && this.data.rol) {
      this.isEdit = true;
      this.vistas = this.data.rol.rolVistas.map((rolVista) => rolVista.vistaId);
      this.rolForm.setValue({
        nombreRol: this.data.rol.nombreRol,
        descripcionRol: this.data.rol.descripcionRol,
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
  }

  onSelectVista(id: number, isChecked: boolean) {
    if (isChecked) {
      this.vistas.push(id);
    } else {
      this.vistas = this.vistas.filter((vista) => vista !== id);
    }
  }
}
