import { NgModule } from '@angular/core';
import { AdministrarComponent } from './administrar.component';
import { RolesComponent } from './roles/roles.component';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RouterModule, Routes } from '@angular/router';
import { ColaboradoresComponent } from './colaboradores/colaboradores.component';
import { DepartamentosComponent } from './departamentos/departamentos.component';
import { AuthGuard } from '../shared/guards/auth.guard';
import { RoleResolver } from '../shared/resolvers/role-resolver.service';
const routes: Routes = [
  {
    path: '',
    component: AdministrarComponent,

    children: [
      {
        path: 'roles',
        component: RolesComponent,
        canActivate: [AuthGuard],
        data: { number: 'sf' },
        resolve: {
          permission: RoleResolver,
        },
      },
      {
        path: 'perfiles',
        component: PerfilesComponent,
        canActivate: [AuthGuard],
        data: { number: 's2' },
        resolve: {
          permission: RoleResolver,
        },
      },
      {
        path: 'colaboradores',
        component: ColaboradoresComponent,
        canActivate: [AuthGuard],
        data: { number: 's3' },
        resolve: {
          permission: RoleResolver,
        },
      },
      {
        path: 'departamentos',
        component: DepartamentosComponent,
        canActivate: [AuthGuard],
        data: { number: 'sl' },
        resolve: {
          permission: RoleResolver,
        },
      },
    ],
    data: { module: 3 },
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdministrarRoutingModule {}
