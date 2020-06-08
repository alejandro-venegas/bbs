import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReportesComponent } from './reportes.component';
import { IncidenteComponent } from './incidente/incidente.component';
import { CasiIncidenteComponent } from './casi-incidente/casi-incidente.component';
import { BbsComponent } from './bbs/bbs.component';
import { CondicionesInsegurasComponent } from './condiciones-inseguras/condiciones-inseguras.component';

const routes: Routes = [
  {
    path: 'reportes',
    component: ReportesComponent,
    children: [
      {
        path: 'incidente',
        component: IncidenteComponent,
        data: { number: 'f' },
      },
      {
        path: 'casi-incidente',
        component: CasiIncidenteComponent,
        data: { number: '2' },
      },
      { path: 'bbs', component: BbsComponent, data: { number: '3' } },
      {
        path: 'condiciones-inseguras',
        component: CondicionesInsegurasComponent,
        data: { number: 'l' },
      },
    ],
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ReportesRoutingModule {}
