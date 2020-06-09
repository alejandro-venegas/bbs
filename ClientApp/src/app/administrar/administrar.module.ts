import { NgModule } from '@angular/core';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RolesComponent } from './roles/roles.component';
import { CommonModule } from '@angular/common';
import { AdministrarRoutingModule } from './administrar-routing.module';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [PerfilesComponent, RolesComponent],
  imports: [
    CommonModule,
    AdministrarRoutingModule,
    MatTabsModule,
    BrowserAnimationsModule,
  ],
  exports: [PerfilesComponent, RolesComponent],
})
export class AdministrarModule {}
