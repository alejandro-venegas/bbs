import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MantenimientoComponent } from './mantenimiento.component';
import { FormulariosComponent } from './formularios/formularios.component';
import { MantenimientoRoutingModule } from './mantenimiento-routing.module';

@NgModule({
  declarations: [
    MantenimientoComponent,
    FormulariosComponent
  ],
  imports: [CommonModule, MantenimientoRoutingModule],
  exports: [
    MantenimientoComponent,
    FormulariosComponent
  ]
})
export class MantenimientoModule {}
