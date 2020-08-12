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
  public chartClicked(e: any): void {}
  public chartHovered(e: any): void {}
  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    const dataSets = this.route.snapshot.data.graphData;

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

  public openPDF(): void {
    const data = this.resultadoElement.nativeElement;
    html2canvas(data).then((canvas) => {
      // Few necessary setting options

      const contentDataURL = canvas.toDataURL("image/png");

      let pdf = new jsPDF("l", "mm", "a4"); // A4 size page of PDF
      pdf.addImage(contentDataURL, "PNG", 15, 15, 260, 130);
      window.open(pdf.output("bloburl")); // Generated PDF
    });
  }
}
