import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GraficosComponent } from './graficos.component';
import { FiltrosComponent } from './filtros/filtros.component';
import { GraficosRoutingModule } from './graficos-routing.module';
import { ResultadosComponent } from './resultados/resultados.component';

@NgModule({
  declarations: [GraficosComponent, FiltrosComponent, ResultadosComponent],
  imports: [CommonModule, GraficosRoutingModule],
  exports: [GraficosComponent, FiltrosComponent, ResultadosComponent]
})
export class GraficosModule {}
