import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { LeftNavComponent } from './left-nav/left-nav.component';
import { ReportesModule } from './reportes/reportes.module';
import { AdministrarModule } from './administrar/administrar.module';
import { GraficosModule } from './graficos/graficos.module';
@NgModule({
  declarations: [AppComponent, HeaderComponent, LeftNavComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReportesModule,
    AdministrarModule,
    GraficosModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
