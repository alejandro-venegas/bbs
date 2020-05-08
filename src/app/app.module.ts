import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ReportesComponent } from './reportes/reportes.component';
import { HeaderComponent } from './header/header.component';
import { LeftNavComponent } from './left-nav/left-nav.component';
import { GraficosComponent } from './graficos/graficos.component';
import { AdministrarComponent } from './administrar/administrar.component';
@NgModule({
  declarations: [
    AppComponent,
    ReportesComponent,
    HeaderComponent,
    LeftNavComponent,
    GraficosComponent,
    AdministrarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
