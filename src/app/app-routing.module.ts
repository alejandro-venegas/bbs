import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReportesComponent } from './reportes/reportes.component';
import { GraficosComponent } from './graficos/graficos.component';
import { AdministrarComponent } from './administrar/administrar.component';

const routes: Routes = [
  { path: '', redirectTo: 'reportes', pathMatch: 'full' },
  { path: 'graficos', component: GraficosComponent },
  { path: 'administrar', component: AdministrarComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
