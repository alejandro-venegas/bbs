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
      { path: 'incidente', component: IncidenteComponent },
      { path: 'casi-incidente', component: CasiIncidenteComponent },
      { path: 'bbs', component: BbsComponent },
      {
        path: 'condiciones-inseguras',
        component: CondicionesInsegurasComponent
      }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReportesRoutingModule {}
