import { Component, Inject, OnInit } from '@angular/core';
import { RolesService } from '../roles/roles.service';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-nuevo-rol-dialog',
  templateUrl: './nuevo-rol-dialog.component.html',
  styleUrls: ['./nuevo-rol-dialog.component.css'],
})
export class NuevoRolDialogComponent implements OnInit {
  isEdit = false;
  rolForm = this.fb.group({
    nombreRol: [''],
    descripcionRol: [''],
  });

  constructor(
    private rolesService: RolesService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<NuevoRolDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit() {
    if (this.data && this.data.rol) {
      this.isEdit = true;
      this.rolForm.setValue({
        nombreRol: this.data.rol.nombreRol,
        descripcionRol: this.data.rol.descripcionRol,
      });
    }
  }

  submitForm() {
    if (this.isEdit) {
      const rol = this.rolForm.value;
      rol.id = this.data.rol && this.data.rol.id;
      this.rolesService.updateRole(rol).subscribe((res) => {
        if (res.status === 202) {
          this.dialogRef.close(true);
        }
      });
    } else {
      this.rolesService.postRole(this.rolForm.value).subscribe((res) => {
        if (res.status === 201) {
          this.dialogRef.close(true);
        }
      });
    }
  }
}
