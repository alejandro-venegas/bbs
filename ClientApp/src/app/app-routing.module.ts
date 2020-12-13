import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReportesComponent } from './reportes/reportes.component';
import { GraficosComponent } from './graficos/graficos.component';
import { MantenimientoComponent } from './mantenimiento/mantenimiento.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { LayoutComponent } from './layout/layout.component';
import { ReportesModule } from './reportes/reportes.module';
import { GraficosModule } from './graficos/graficos.module';
import { AdministrarModule } from './administrar/administrar.module';
import { MantenimientoModule } from './mantenimiento/mantenimiento.module';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './shared/guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'reportes', pathMatch: 'full' },
  { path: 'reportes', loadChildren: () => ReportesModule },
  { path: 'graficos', loadChildren: () => GraficosModule },
  { path: 'administrar', loadChildren: () => AdministrarModule },
  { path: 'mantenimiento', loadChildren: () => MantenimientoModule },
  { path: 'forbidden', component: ForbiddenComponent },
  { path: '**', redirectTo: 'reportes' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
