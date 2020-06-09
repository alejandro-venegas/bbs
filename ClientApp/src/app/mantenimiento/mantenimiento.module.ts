import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MantenimientoComponent } from './mantenimiento.component';
import { FormulariosComponent } from './formularios/formularios.component';
import { MantenimientoRoutingModule } from './mantenimiento-routing.module';
import { MatTabsModule } from '@angular/material/tabs';

@NgModule({
  declarations: [MantenimientoComponent, FormulariosComponent],
  imports: [CommonModule, MantenimientoRoutingModule, MatTabsModule],
  exports: [MantenimientoComponent, FormulariosComponent],
})
export class MantenimientoModule {}
