import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GraficosComponent } from './graficos.component';
import { FiltrosComponent } from './filtros/filtros.component';
import { GraficosRoutingModule } from './graficos-routing.module';
import { ResultadosComponent } from './resultados/resultados.component';
import { MatRadioModule } from '@angular/material/radio';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [GraficosComponent, FiltrosComponent, ResultadosComponent],
  imports: [
    CommonModule,
    GraficosRoutingModule,
    MatRadioModule,
    MatTabsModule,
    BrowserAnimationsModule,
  ],
  exports: [GraficosComponent, FiltrosComponent, ResultadosComponent],
})
export class GraficosModule {}
