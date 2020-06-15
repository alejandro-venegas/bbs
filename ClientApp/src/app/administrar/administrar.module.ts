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
import { ReactiveFormsModule } from '@angular/forms';
import { DepartamentosComponent } from './departamentos/departamentos.component';
import { ColaboradoresComponent } from './colaboradores/colaboradores.component';
import { NuevoColaboradorDialogComponent } from './colaboradores/nuevo-colaborador-dialog/nuevo-colaborador-dialog.component';
import { NuevoDepartamentoDialogComponent } from './departamentos/nuevo-departamento-dialog/nuevo-departamento-dialog.component';

@NgModule({
  declarations: [
    PerfilesComponent,
    RolesComponent,
    NuevoRolDialogComponent,
    DepartamentosComponent,
    ColaboradoresComponent,
    NuevoColaboradorDialogComponent,
    NuevoDepartamentoDialogComponent,
  ],
  imports: [
    CommonModule,
    AdministrarRoutingModule,
    MatTabsModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatCheckboxModule,
    ReactiveFormsModule,
  ],
  exports: [PerfilesComponent, RolesComponent],
})
export class AdministrarModule {}
