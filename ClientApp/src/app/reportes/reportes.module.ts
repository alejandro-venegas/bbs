import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReportesComponent } from './reportes.component';
import { IncidenteComponent } from './incidente/incidente.component';
import { CasiIncidenteComponent } from './casi-incidente/casi-incidente.component';
import { BbsComponent } from './bbs/bbs.component';
import { CondicionesInsegurasComponent } from './condiciones-inseguras/condiciones-inseguras.component';
import { ReportesRoutingModule } from './reportes-routing.module';

@NgModule({
  declarations: [
    ReportesComponent,
    IncidenteComponent,
    CasiIncidenteComponent,
    BbsComponent,
    CondicionesInsegurasComponent
  ],
  imports: [CommonModule, ReportesRoutingModule],
  exports: [
    ReportesComponent,
    IncidenteComponent,
    CasiIncidenteComponent,
    BbsComponent,
    CondicionesInsegurasComponent
  ]
})
export class ReportesModule {}
