import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MantenimientoComponent } from './mantenimiento.component';
import { FormulariosComponent } from './formularios/formularios.component';
import { MantenimientoRoutingModule } from './mantenimiento-routing.module';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatTreeModule } from '@angular/material/tree';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { AutofocusDirective } from '../shared/directives/autofocus.directive';
import { CdkScrollableModule } from '@angular/cdk/scrolling';
import { RoleResolver } from '../shared/resolvers/role-resolver.service';
import { BitacoraComponent } from './bitacora/bitacora.component';

@NgModule({
  declarations: [
    MantenimientoComponent,
    FormulariosComponent,
    AutofocusDirective,
    BitacoraComponent,
  ],
  imports: [
    CommonModule,
    MantenimientoRoutingModule,
    MatTabsModule,
    MatTableModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatTreeModule,
    MatButtonModule,
    MatIconModule,
    CdkScrollableModule,
  ],
  exports: [MantenimientoComponent, FormulariosComponent],
  providers: [RoleResolver],
})
export class MantenimientoModule {}
