import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import 'hammerjs';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { LeftNavComponent } from './left-nav/left-nav.component';
import { ReportesModule } from './reportes/reportes.module';
import { MantenimientoModule } from './mantenimiento/mantenimiento.module';
import { GraficosModule } from './graficos/graficos.module';
import { AdministrarComponent } from './administrar/administrar.component';
import { AdministrarModule } from './administrar/administrar.module';
import {
  BrowserAnimationsModule,
  NoopAnimationsModule,
} from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material/tabs';
import { EliminarDialogComponent } from './shared/dialogs/eliminar-dialog/eliminar-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './login/login.component';
import { AuthInterceptor } from './shared/interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LeftNavComponent,
    AdministrarComponent,
    EliminarDialogComponent,
    ForbiddenComponent,
    LayoutComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReportesModule,
    MantenimientoModule,
    GraficosModule,
    AdministrarModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    MatTabsModule,
    MatDialogModule,
    MatIconModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
  exports: [],
})
export class AppModule {}
