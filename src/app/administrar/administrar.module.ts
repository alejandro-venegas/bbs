import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdministrarComponent } from './administrar.component';
import { RolesComponent } from './roles/roles.component';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { FormulariosComponent } from './formularios/formularios.component';
import { AdministrarRoutingModule } from './administrar-routing.module';

@NgModule({
  declarations: [
    AdministrarComponent,
    RolesComponent,
    PerfilesComponent,
    FormulariosComponent
  ],
  imports: [CommonModule, AdministrarRoutingModule],
  exports: [
    AdministrarComponent,
    RolesComponent,
    PerfilesComponent,
    FormulariosComponent
  ]
})
export class AdministrarModule {}
