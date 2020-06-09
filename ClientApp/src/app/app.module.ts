import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { LeftNavComponent } from './left-nav/left-nav.component';
import { ReportesModule } from './reportes/reportes.module';
import { MantenimientoModule } from './mantenimiento/mantenimiento.module';
import { GraficosModule } from './graficos/graficos.module';
import { AdministrarComponent } from './administrar/administrar.component';
import { AdministrarModule } from './administrar/administrar.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material/tabs';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LeftNavComponent,
    AdministrarComponent,
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
    MatTabsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
