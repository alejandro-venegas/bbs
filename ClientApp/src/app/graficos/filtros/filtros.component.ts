import { Component, OnInit } from "@angular/core";
import { NgForm, Validators } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
  selector: "app-filtros",
  templateUrl: "./filtros.component.html",
  styleUrls: ["./filtros.component.css"],
})
export class FiltrosComponent implements OnInit {
  propiedadesArray = [];
  dataSetArray = [];
  constructor(private router: Router) {}

  ngOnInit(): void {}
  submitForm(form: NgForm) {
    console.log(form);

    this.router.navigate(["graficos/resultado"], {
      queryParams: {
        tiposGraficas: this.dataSetArray.join(","),
        propiedades: this.propiedadesArray.join(","),
      },
    });
  }

  propiedadChange(propiedadValue: string) {
    if (this.propiedadesArray.includes(propiedadValue)) {
      this.propiedadesArray = this.propiedadesArray.filter(
        (propiedad) => propiedad != propiedadValue
      );
    } else {
      this.propiedadesArray.push(propiedadValue);
    }
    console.log(this.propiedadesArray);
  }

  dataSetChange(dataSetValue: string) {
    if (this.dataSetArray.includes(dataSetValue)) {
      this.dataSetArray = this.dataSetArray.filter((propiedad) => {
        return propiedad !== dataSetValue;
      });
    } else {
      this.dataSetArray.push(dataSetValue);
    }
    console.log(this.dataSetArray);
  }

  isSelected(dataSetName: string): boolean {
    return this.dataSetArray.includes(dataSetName);
  }
}
