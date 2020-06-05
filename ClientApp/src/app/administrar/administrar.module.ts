import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdministrarComponent } from './administrar.component';
import { FormulariosComponent } from './formularios/formularios.component';
import { AdministrarRoutingModule } from './administrar-routing.module';

@NgModule({
  declarations: [
    AdministrarComponent,
    FormulariosComponent
  ],
  imports: [CommonModule, AdministrarRoutingModule],
  exports: [
    AdministrarComponent,
    FormulariosComponent
  ]
})
export class AdministrarModule {}
