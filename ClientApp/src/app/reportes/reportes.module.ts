import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReportesComponent } from './reportes.component';
import { IncidenteComponent } from './incidente/incidente.component';
import { CasiIncidenteComponent } from './casi-incidente/casi-incidente.component';
import { BbsComponent } from './bbs/bbs.component';
import { CondicionesInsegurasComponent } from './condiciones-inseguras/condiciones-inseguras.component';
import { ReportesRoutingModule } from './reportes-routing.module';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ReportesComponent,
    IncidenteComponent,
    CasiIncidenteComponent,
    BbsComponent,
    CondicionesInsegurasComponent,
  ],
  imports: [
    CommonModule,
    ReportesRoutingModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    MatTabsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ],
  exports: [
    ReportesComponent,
    IncidenteComponent,
    CasiIncidenteComponent,
    BbsComponent,
    CondicionesInsegurasComponent,
  ],
})
export class ReportesModule {}
