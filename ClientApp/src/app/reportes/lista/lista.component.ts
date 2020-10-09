import { Component, OnInit, ViewChild } from "@angular/core";
import { rowAnimation } from "../../animations";
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator } from "@angular/material/paginator";
import { ReportesService } from "../reportes.service";
import { ActivatedRoute, Router } from "@angular/router";
import { EliminarDialogComponent } from "../../shared/dialogs/eliminar-dialog/eliminar-dialog.component";
import { MatDialog } from "@angular/material/dialog";

@Component({
  selector: "app-lista",
  templateUrl: "./lista.component.html",
  styleUrls: ["./lista.component.css"],
  animations: [rowAnimation],
})
export class ListaComponent implements OnInit {
  editable: boolean;
  reportes: any[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource([]);

  constructor(
    private reportesService: ReportesService,
    private router: Router,
    private route: ActivatedRoute,
    private dialog: MatDialog
  ) {}
  displayedColumns: string[] = [
      "indice",
    "fecha",
    "tipo",
    "observado",
    "areaDeTrabajo",
    "accion",
  ];
  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.editable = data.permission;
    });
    this.dataSource.paginator = this.paginator;
    this.getReportes();
  }

  onEditarReporte(id: number, tipo: string) {
    let route: string;
    switch (tipo) {
      case "BBS":
        route = "bbs";
        break;
      case "Casi Incidente":
        route = "casi-incidente";
        break;
      case "Incidente":
        route = "incidente";
        break;
      case "Condicion Insegura":
        route = "condiciones-inseguras";
        break;
    }
    this.router.navigate(["../" + route], {
      queryParams: { id },
      relativeTo: this.route,
    });
  }

  getReportes() {
    this.reportesService.getBbss().subscribe((resBbs) => {
      for (const bbs of resBbs) {
        bbs.tipo = "BBS";
      }
      this.reportes = resBbs;
      this.reportesService.getCasiIncidentes().subscribe((resCasiIncidente) => {
        for (const casiIncidente of resCasiIncidente) {
          casiIncidente.tipo = "Casi Incidente";
        }
        this.reportes = [...this.reportes, ...resCasiIncidente];
        this.reportesService.getIncidentes().subscribe((resIncidente) => {
          for (const incidente of resIncidente) {
            incidente.tipo = "Incidente";
          }
          this.reportes = [...this.reportes, ...resIncidente];

          this.reportesService
            .getCondicionesInseguras()
            .subscribe((resCondicionesInseguras) => {
              for (const condicionInsegura of resCondicionesInseguras) {
                condicionInsegura.tipo = "Condicion Insegura";
              }
              this.reportes = [...this.reportes, ...resCondicionesInseguras];

              this.reportes.sort(
                (a, b) => -Date.parse(a.fecha) + Date.parse(b.fecha)
              );
              this.dataSource.data = this.reportes;
            });
        });
      });
    });
  }

  onDeleteReporte(id: number, tipo: string) {
    this.dialog
      .open(EliminarDialogComponent, {
        minWidth: "35vw",
        data: {
          title: "ELIMINAR REPORTE",
          content: `Desea eliminar el reporte de ${tipo}?`,
        },
      })
      .afterClosed()
      .subscribe((res) => {
        if (res) {
          switch (tipo) {
            case "BBS":
              this.reportesService.deleteBbs(id).subscribe((res) => {
                if (res.status === 202) {
                  this.getReportes();
                }
              });
              break;
            case "Incidente":
              this.reportesService.deleteIncidente(id).subscribe((res) => {
                if (res.status === 202) {
                  this.getReportes();
                }
              });
              break;
            case "Casi Incidente":
              this.reportesService.deleteCasiIncidente(id).subscribe((res) => {
                if (res.status === 202) {
                  this.getReportes();
                }
              });
              break;
            case "Condicion Insegura":
              this.reportesService
                .deleteCondicionInsegura(id)
                .subscribe((res) => {
                  if (res.status === 202) {
                    this.getReportes();
                  }
                });
              break;
          }
        }
      });
  }
}
