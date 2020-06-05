import { NgModule } from '@angular/core';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RolesComponent } from './roles/roles.component';
import { CommonModule } from '@angular/common';
import { RolesPerfilesRoutingModule } from './roles-perfiles-routing.module';

@NgModule({
    declarations: [PerfilesComponent, RolesComponent],
    imports: [CommonModule, RolesPerfilesRoutingModule],
    exports: [PerfilesComponent, RolesComponent],
})
export class RolesPerfilesModule{}