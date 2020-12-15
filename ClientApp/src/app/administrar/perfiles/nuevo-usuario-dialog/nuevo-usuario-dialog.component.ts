import { Component, Inject, OnInit } from '@angular/core';
import { Departamento } from '../../../shared/models/departamento.model';
import { FormBuilder, Validators } from '@angular/forms';
import { Colaborador } from '../../../shared/models/colaborador.model';
import { Rol } from '../../../shared/models/rol.model';
import { ColaboradoresService } from '../../../shared/services/colaboradores.service';
import { RolesService } from '../../roles/roles.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AuthService } from '../../../shared/services/auth.service';

@Component({
  selector: 'app-nuevo-usuario-dialog',
  templateUrl: './nuevo-usuario-dialog.component.html',
  styleUrls: ['./nuevo-usuario-dialog.component.scss'],
})
export class NuevoUsuarioDialogComponent implements OnInit {
  isEdit = false;
  colaboradores: Colaborador[] = [];
  roles: Rol[] = [];
  usuarioForm = this.fb.group({
    colaboradorId: ['', [Validators.required]],
    username: ['', [Validators.required]],
    rolId: ['', [Validators.required]],
  });
  constructor(
    private fb: FormBuilder,
    private colaboradoresService: ColaboradoresService,
    private rolesService: RolesService,
    private dialogRef: MatDialogRef<NuevoUsuarioDialogComponent>,
    private authService: AuthService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  get colaboradorId() {
    return this.usuarioForm.get('colaboradorId');
  }

  get username() {
    return this.usuarioForm.get('username');
  }

  get rolId() {
    return this.usuarioForm.get('rolId');
  }

  ngOnInit(): void {
    this.colaboradoresService
      .getColaboradores()
      .subscribe(
        (res) => (this.colaboradores = res.filter((value) => !value.usuario))
      );
    this.rolesService.getRoles().subscribe((res) => (this.roles = res));
    if (this.data && this.data.perfil) {
      console.log(this.data.perfil);
      this.isEdit = true;
      this.usuarioForm.patchValue(this.data.perfil);
    }
  }

  submitForm() {
    if (this.usuarioForm.valid) {
      const value = this.usuarioForm.value;
      if (this.isEdit) {
        value.id = this.data.perfil.id;
        this.authService.updateUser(value).subscribe((res) => {
          console.log(res);
          if (res.status === 202) {
            this.dialogRef.close(true);
          }
        });
      } else {
        this.authService.createNewUser(value).subscribe((res) => {
          console.log(res);
          if (res.status === 201) {
            this.dialogRef.close(true);
          }
        });
      }
    }
  }
}
