import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormulariosComponent } from './formularios/formularios.component';
import { MantenimientoComponent } from './mantenimiento.component';
const routes: Routes = [
  {
    path: 'mantenimiento',
    component: MantenimientoComponent,
    children: [
      {
        path: 'formularios',
        component: FormulariosComponent,
        data: { number: 's1' },
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
