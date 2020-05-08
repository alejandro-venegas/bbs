import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GraficosComponent } from './graficos.component';
import { FiltrosComponent } from './filtros/filtros.component';
import { ResultadosComponent } from './resultados/resultados.component';

const routes: Routes = [
  {
    path: 'graficos',
    component: GraficosComponent,
    children: [
      { path: 'filtros', component: FiltrosComponent },
      { path: 'resultado', component: ResultadosComponent }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GraficosRoutingModule {}
