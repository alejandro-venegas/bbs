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
  { path: 'login', component: LoginComponent, pathMatch: 'full' },

  { path: '', redirectTo: 'reportes', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'reportes',
        loadChildren: () => ReportesModule,
        data: { module: 'f' },
      },
      {
        path: 'graficos',
        loadChildren: () => GraficosModule,
        data: { module: '2' },
      },
      {
        path: 'administrar',
        loadChildren: () => AdministrarModule,
        data: { module: '3' },
      },
      {
        path: 'mantenimiento',
        loadChildren: () => MantenimientoModule,
        data: { module: 'l' },
      },
      { path: 'forbidden', component: ForbiddenComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
