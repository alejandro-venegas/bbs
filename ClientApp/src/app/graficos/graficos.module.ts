import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { GraficosComponent } from "./graficos.component";
import { FiltrosComponent } from "./filtros/filtros.component";
import { GraficosRoutingModule } from "./graficos-routing.module";
import { ResultadosComponent } from "./resultados/resultados.component";
import { MatRadioModule } from "@angular/material/radio";
import { MatTabsModule } from "@angular/material/tabs";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { ChartsModule, WavesModule } from "angular-bootstrap-md";
import { FormsModule } from "@angular/forms";
import { ResultadoResolver } from "./resultados/resultado-resolver.service";

@NgModule({
  declarations: [GraficosComponent, FiltrosComponent, ResultadosComponent],
  imports: [
    CommonModule,
    GraficosRoutingModule,
    MatRadioModule,
    MatTabsModule,
    BrowserAnimationsModule,
    MatCheckboxModule,
    ChartsModule,
    WavesModule,
    FormsModule,
  ],
  exports: [GraficosComponent, FiltrosComponent, ResultadosComponent],
  providers: [ResultadoResolver],
})
export class GraficosModule {}
