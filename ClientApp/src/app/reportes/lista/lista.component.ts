import { Component, OnInit, ViewChild } from '@angular/core';
import { rowAnimation } from '../../animations';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ReportesService } from '../reportes.service';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css'],
  animations: [rowAnimation],
})
export class ListaComponent implements OnInit {
  reportes: any[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource([]);

  constructor(private reportesService: ReportesService) {}
  displayedColumns: string[] = [
    'fecha',
    'tipo',
    'observado',
    'areaDeTrabajo',
    'accion',
  ];
  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
    this.getReportes();
  }

  getReportes() {
    this.reportesService.getBbss().subscribe((resBbs) => {
      for (const bbs of resBbs) {
        bbs.tipo = 'BBS';
      }
      this.reportes = resBbs;
      this.reportesService.getCasiIncidentes().subscribe((resCasiIncidente) => {
        for (const casiIncidente of resCasiIncidente) {
          casiIncidente.tipo = 'Casi Incidente';
        }
        this.reportes = [...this.reportes, ...resCasiIncidente];
        this.reportesService.getIncidentes().subscribe((resIncidente) => {
          for (const incidente of resIncidente) {
            incidente.tipo = 'Incidente';
          }
          this.reportes = [...this.reportes, ...resIncidente];

          this.reportesService
            .getCondicionesInseguras()
            .subscribe((resCondicionesInseguras) => {
              for (const condicionInsegura of resCondicionesInseguras) {
                condicionInsegura.tipo = 'Condicion Insegura';
              }
              this.reportes = [...this.reportes, ...resCondicionesInseguras];

              for (const reporte of this.reportes) {
                reporte.fecha =
                  reporte.fechaCondicion ||
                  reporte.fechaBbs ||
                  reporte.fechaCasiIncidente ||
                  reporte.fechaIncidente;
              }
              this.reportes.sort(
                (a, b) => -Date.parse(a.fecha) + Date.parse(b.fecha)
              );
              this.dataSource.data = this.reportes;
            });
        });
      });
    });
  }
}
