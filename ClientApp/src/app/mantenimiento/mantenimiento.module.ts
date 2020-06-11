import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MantenimientoComponent } from './mantenimiento.component';
import { FormulariosComponent } from './formularios/formularios.component';
import { MantenimientoRoutingModule } from './mantenimiento-routing.module';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [MantenimientoComponent, FormulariosComponent],
  imports: [
    CommonModule,
    MantenimientoRoutingModule,
    MatTabsModule,
    MatTableModule,
    MatPaginatorModule,
  ],
  exports: [MantenimientoComponent, FormulariosComponent],
})
export class MantenimientoModule {}
