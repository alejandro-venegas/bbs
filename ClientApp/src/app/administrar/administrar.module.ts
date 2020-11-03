import { NgModule } from '@angular/core';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RolesComponent } from './roles/roles.component';
import { CommonModule } from '@angular/common';
import { AdministrarRoutingModule } from './administrar-routing.module';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { NuevoRolDialogComponent } from './roles/nuevo-rol-dialog/nuevo-rol-dialog.component';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepartamentosComponent } from './departamentos/departamentos.component';
import { ColaboradoresComponent } from './colaboradores/colaboradores.component';
import { NuevoColaboradorDialogComponent } from './colaboradores/nuevo-colaborador-dialog/nuevo-colaborador-dialog.component';
import { NuevoDepartamentoDialogComponent } from './departamentos/nuevo-departamento-dialog/nuevo-departamento-dialog.component';
import { RoleResolver } from '../shared/resolvers/role-resolver.service';
import { NuevoUsuarioDialogComponent } from './perfiles/nuevo-usuario-dialog/nuevo-usuario-dialog.component';

@NgModule({
  declarations: [
    PerfilesComponent,
    RolesComponent,
    NuevoRolDialogComponent,
    DepartamentosComponent,
    ColaboradoresComponent,
    NuevoColaboradorDialogComponent,
    NuevoDepartamentoDialogComponent,
    NuevoUsuarioDialogComponent,
  ],
  imports: [
    CommonModule,
    AdministrarRoutingModule,
    MatTabsModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  exports: [PerfilesComponent, RolesComponent],
  providers: [RoleResolver],
})
export class AdministrarModule {}
