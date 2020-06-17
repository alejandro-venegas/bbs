import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReportesComponent } from './reportes.component';
import { IncidenteComponent } from './incidente/incidente.component';
import { CasiIncidenteComponent } from './casi-incidente/casi-incidente.component';
import { BbsComponent } from './bbs/bbs.component';
import { CondicionesInsegurasComponent } from './condiciones-inseguras/condiciones-inseguras.component';
import { ListaComponent } from './lista/lista.component';

const routes: Routes = [
  {
    path: 'reportes',
    component: ReportesComponent,
    children: [
      { path: 'lista', component: ListaComponent, data: { number: 'sf' } },
      {
        path: 'incidente',
        component: IncidenteComponent,
        data: { number: 's2' },
      },
      {
        path: 'casi-incidente',
        component: CasiIncidenteComponent,
        data: { number: 's3' },
      },
      { path: 'bbs', component: BbsComponent, data: { number: 's4' } },
      {
        path: 'condiciones-inseguras',
        component: CondicionesInsegurasComponent,
        data: { number: 'sl' },
      },
    ],
    data: { module: 'f' },
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ReportesRoutingModule {}
