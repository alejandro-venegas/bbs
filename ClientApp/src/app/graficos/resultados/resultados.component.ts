import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
} from "@angular/core";
import { GraficosService } from "./graficos.service";
import { ActivatedRoute } from "@angular/router";
import { rowAnimation } from "../../animations";
import * as jsPDF from "jspdf";
import html2canvas from "html2canvas";
@Component({
  selector: "app-resultados",
  templateUrl: "./resultados.component.html",
  styleUrls: ["./resultados.component.css"],
  animations: [rowAnimation],
})
export class ResultadosComponent implements OnInit {
  public chartType: string = "bar";

  public tipoGraficas: string;
  public startDate: Date;
  public endDate: Date;


  public chartDatasets: Array<any> = [];

  @ViewChild("resultadoElement") resultadoElement: ElementRef;

  public chartLabels: Array<any> = [];

  public chartOptions: any = {
    legend: {
      labels: {
        fontColor: "white",
      },
    },
    scaleShowValues: true,
    scales: {
      xAxes: [
        {
          ticks: {
            autoSkip: false,
            fontColor: "white",
          },
          gridLines: {
            color: "rgba(255,255,255,0.5)",
          },
        },
      ],
      yAxes: [
        {
          ticks: {
            fontColor: "white",
            beginAtZero: true,
          },
          gridLines: {
            color: "rgba(255,255,255,0.5)",
          },
        },
      ],
    },
  };
  public propiedades: any;
  public chartClicked(e: any): void {}
  public chartHovered(e: any): void {}
  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {

    const dataSets = this.route.snapshot.data.graphData;

    this.tipoGraficas = this.textParser(this.route.snapshot.queryParams.tiposGraficas, ',').map((value) =>
      this.textParser(value, '-').join(' ')
    ).map((value, index, array) => {
      if(index === array.length - 2){
        return this.capitalizeWord(value) + ' y';
      }
      return this.capitalizeWord(value) + ',';
    }).join(' ');
    this.propiedades = this.capitalizeWord(this.textParser(this.route.snapshot.queryParams.propiedades, '-').join( ' '));

    this.startDate = new Date(this.route.snapshot.queryParams.startDate);
    this.endDate = new Date(this.route.snapshot.queryParams.endDate);

    for (let dataSet of dataSets) {
      let dataSetName = dataSet.dataSet.split("-");
      dataSetName = dataSetName.join(" ");
      dataSetName = dataSetName[0].toUpperCase() + dataSetName.slice(1);

      const values = [];

      for (const datum of dataSet.data) {
        const labelExists = this.chartLabels.includes(datum.label);
        if (!labelExists) {
          this.chartLabels.push(datum.label);
        }

        this.chartLabels.forEach((value, index) => {
          if (value === datum.label) {
            values[index] = datum.count;
          } else if (typeof values[index] !== "number") {
            values[index] = 0;
          }
        });
      }
      this.chartDatasets.push({ data: values, label: dataSetName });
    }
  }

  textParser(str: string, splitString: string){
    let resultString = '';
    const strArray = str.split(splitString);
    return strArray;
  }
  capitalizeWord(word: string){
    return word.charAt(0).toUpperCase() + word.slice(1);
  }

  public openPDF(): void {
    const data = this.resultadoElement.nativeElement;
    html2canvas(data).then((canvas) => {
      // Few necessary setting options

      const contentDataURL = canvas.toDataURL("image/png");

      let pdf = new jsPDF("l", "mm", "a4"); // A4 size page of PDF
      pdf.text(`Gráfico de ${this.tipoGraficas} Vs. ${this.propiedades}`, pdf.internal.pageSize.width / 2, 15, null, null, 'center');
      pdf.text(`${this.startDate.toLocaleDateString('en-GB')} - ${this.endDate.toLocaleDateString('en-GB')}`, pdf.internal.pageSize.width / 2, 30, null, null, 'center');
      pdf.addImage(contentDataURL, "PNG", 15, 45, 260, 130);
      window.open(pdf.output("bloburl")); // Generated PDF
    });
  }
}
