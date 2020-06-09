import { NgModule } from '@angular/core';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RolesComponent } from './roles/roles.component';
import { CommonModule } from '@angular/common';
import { AdministrarRoutingModule } from './administrar-routing.module';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [PerfilesComponent, RolesComponent],
  imports: [
    CommonModule,
    AdministrarRoutingModule,
    MatTabsModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
  ],
  exports: [PerfilesComponent, RolesComponent],
})
export class AdministrarModule {}
