import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReportesComponent } from './reportes/reportes.component';
import { GraficosComponent } from './graficos/graficos.component';
import { MantenimientoComponent } from './mantenimiento/mantenimiento.component';

const routes: Routes = [
  { path: '', redirectTo: 'reportes', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
