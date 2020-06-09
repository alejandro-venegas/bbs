import { NgModule } from '@angular/core';
import { AdministrarComponent } from './administrar.component';
import { RolesComponent } from './roles/roles.component';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RouterModule, Routes } from '@angular/router';
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
