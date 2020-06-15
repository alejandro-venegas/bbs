import { NgModule } from '@angular/core';
import { AdministrarComponent } from './administrar.component';
import { RolesComponent } from './roles/roles.component';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RouterModule, Routes } from '@angular/router';
import { ColaboradoresComponent } from './colaboradores/colaboradores.component';
import { DepartamentosComponent } from './departamentos/departamentos.component';
const routes: Routes = [
  {
    path: 'administrar',
    component: AdministrarComponent,
    children: [
      {
        path: 'roles',
        component: RolesComponent,
        data: { number: 'sf' },
      },
      {
        path: 'perfiles',
        component: PerfilesComponent,
        data: { number: 's2' },
      },
      {
        path: 'colaboradores',
        component: ColaboradoresComponent,
        data: { number: 's3' },
      },
      {
        path: 'departamentos',
        component: DepartamentosComponent,
        data: { number: 'sl' },
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
