import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReportesComponent } from './reportes.component';
import { IncidenteComponent } from './incidente/incidente.component';
import { CasiIncidenteComponent } from './casi-incidente/casi-incidente.component';
import { BbsComponent } from './bbs/bbs.component';
import { CondicionesInsegurasComponent } from './condiciones-inseguras/condiciones-inseguras.component';
import { ListaComponent } from './lista/lista.component';
import { AuthGuard } from '../shared/guards/auth.guard';
import { RoleResolver } from '../shared/resolvers/role-resolver.service';

const routes: Routes = [
  {
    path: 'reportes',
    component: ReportesComponent,
    children: [
      {
        path: 'lista',
        component: ListaComponent,
        data: { number: 'sf' },
        canActivate: [AuthGuard],
        resolve: {
          permission: RoleResolver,
        },
      },
      {
        path: 'incidente',
        component: IncidenteComponent,
        data: { number: 's2' },
        canActivate: [AuthGuard],
        resolve: {
          permission: RoleResolver,
        },
      },
      {
        path: 'casi-incidente',
        component: CasiIncidenteComponent,
        data: { number: 's3' },
        canActivate: [AuthGuard],
        resolve: {
          permission: RoleResolver,
        },
      },
      {
        path: 'bbs',
        component: BbsComponent,
        data: { number: 's4' },
        canActivate: [AuthGuard],
        resolve: {
          permission: RoleResolver,
        },
      },
      {
        path: 'condiciones-inseguras',
        component: CondicionesInsegurasComponent,
        data: { number: 'sl' },
        canActivate: [AuthGuard],
        resolve: {
          permission: RoleResolver,
        },
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
