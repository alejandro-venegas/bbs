import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReportesComponent } from './reportes.component';
import { IncidenteComponent } from './incidente/incidente.component';
import { CasiIncidenteComponent } from './casi-incidente/casi-incidente.component';
import { BbsComponent } from './bbs/bbs.component';
import { CondicionesInsegurasComponent } from './condiciones-inseguras/condiciones-inseguras.component';
import { ReportesRoutingModule } from './reportes-routing.module';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { ListaComponent } from './lista/lista.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    ReportesComponent,
    IncidenteComponent,
    CasiIncidenteComponent,
    BbsComponent,
    CondicionesInsegurasComponent,
    ListaComponent,
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
    MatTableModule,
    MatPaginatorModule,
  ],
  exports: [
    ReportesComponent,
    IncidenteComponent,
    CasiIncidenteComponent,
    BbsComponent,
    CondicionesInsegurasComponent,
  ],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'en-GB' }],
})
export class ReportesModule {}
