import { AfterViewInit, Component, OnInit } from "@angular/core";
import { GraficosService } from "./graficos.service";
import { ActivatedRoute } from "@angular/router";
import { rowAnimation } from "../../animations";
@Component({
  selector: "app-resultados",
  templateUrl: "./resultados.component.html",
  styleUrls: ["./resultados.component.css"],
  animations: [rowAnimation],
})
export class ResultadosComponent implements OnInit {
  public chartType: string = "bar";

  public chartDatasets: Array<any> = [
    { data: [65, 59, 80, 81, 56, 55, 40], label: "My First dataset" },
  ];

  public chartLabels: Array<any> = [
    "Red",
    "Blue",
    "Yellow",
    "Green",
    "Purple",
    "Orange",
  ];

  public chartOptions: any = {
    responsive: true,
    maintainAspectRatio: true,
    legend: {
      labels: {
        fontColor: "white",
      },
    },
    scales: {
      xAxes: [
        {
          ticks: {
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
    const data = this.route.snapshot.data.graphData;
    const dataSetParam = this.route.snapshot.queryParams.tipoGrafica;
    let dataSet = dataSetParam.split("-");
    dataSet = dataSet.join(" ");
    dataSet = dataSet[0].toUpperCase() + dataSet.slice(1);
    const labels = data.map((datum) => datum.label);
    const values = data.map((datum) => datum.count);

    this.chartDatasets = [{ data: values, label: dataSet }];
    this.chartLabels = labels;
  }
}
