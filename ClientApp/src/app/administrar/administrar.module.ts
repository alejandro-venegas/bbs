import { NgModule } from '@angular/core';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RolesComponent } from './roles/roles.component';
import { CommonModule } from '@angular/common';
import { AdministrarRoutingModule } from './administrar-routing.module';

@NgModule({
    declarations: [PerfilesComponent, RolesComponent],
    imports: [CommonModule, AdministrarRoutingModule],
    exports: [PerfilesComponent, RolesComponent],
})
export class AdministrarModule{}
