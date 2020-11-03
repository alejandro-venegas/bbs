import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormulariosComponent } from './formularios/formularios.component';
import { MantenimientoComponent } from './mantenimiento.component';
import { AuthGuard } from '../shared/guards/auth.guard';
import { RoleResolver } from '../shared/resolvers/role-resolver.service';
import { BitacoraComponent } from './bitacora/bitacora.component';
const routes: Routes = [
  {
    path: '',
    component: MantenimientoComponent,
    children: [
      {
        path: 'formularios',
        component: FormulariosComponent,
        data: { number: 'sf' },
        canActivate: [AuthGuard],
        resolve: {
          permission: RoleResolver,
        },
      },
      {
        path: 'bitacora',
        component: BitacoraComponent,
        data: { number: 'sl' },
        canActivate: [AuthGuard],
        resolve: {
          permission: RoleResolver,
        },
      },
    ],
    data: {
      module: 'l',
    },
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MantenimientoRoutingModule {}
