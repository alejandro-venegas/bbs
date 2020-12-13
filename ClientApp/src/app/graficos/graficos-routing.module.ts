import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GraficosComponent } from './graficos.component';
import { FiltrosComponent } from './filtros/filtros.component';
import { ResultadosComponent } from './resultados/resultados.component';
import { AuthGuard } from '../shared/guards/auth.guard';
import { ResultadoResolver } from './resultados/resultado-resolver.service';

const routes: Routes = [
  {
    path: '',
    component: GraficosComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'filtros', component: FiltrosComponent, data: { number: 'sf' } },
      {
        path: 'resultado',
        component: ResultadosComponent,
        resolve: {
          graphData: ResultadoResolver,
        },
        data: { number: 'sl' },
      },
    ],
    data: {
      module: '2',
    },
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GraficosRoutingModule {}
