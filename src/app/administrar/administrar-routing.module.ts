import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RolesComponent } from './roles/roles.component';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { FormulariosComponent } from './formularios/formularios.component';
import { AdministrarComponent } from './administrar.component';
const routes: Routes = [
  {
    path: 'administrar',
    component: AdministrarComponent,
    children: [
      {
        path: 'roles',
        component: RolesComponent
      },
      {
        path: 'perfiles',
        component: PerfilesComponent
      },
      {
        path: 'formularios',
        component: FormulariosComponent
      }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrarRoutingModule {}
