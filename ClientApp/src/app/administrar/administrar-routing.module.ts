import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormulariosComponent } from './formularios/formularios.component';
import { AdministrarComponent } from './administrar.component';
const routes: Routes = [
  {
    path: 'administrar',
    component: AdministrarComponent,
    children: [
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
