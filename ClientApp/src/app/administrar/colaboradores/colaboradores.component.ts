import { Component, OnInit, ViewChild } from "@angular/core";
import { rowAnimation } from "../../animations";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { NuevoRolDialogComponent } from "../roles/nuevo-rol-dialog/nuevo-rol-dialog.component";
import { MatDialog } from "@angular/material/dialog";
import { NuevoColaboradorDialogComponent } from "./nuevo-colaborador-dialog/nuevo-colaborador-dialog.component";
import { ColaboradoresService } from "../../shared/services/colaboradores.service";
import { Colaborador } from "../../shared/models/colaborador.model";
import { Rol } from "../../shared/models/rol.model";
import { EliminarDialogComponent } from "../../shared/dialogs/eliminar-dialog/eliminar-dialog.component";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-colaboradores",
  templateUrl: "./colaboradores.component.html",
  styleUrls: ["./colaboradores.component.css"],
  animations: [rowAnimation],
})
export class ColaboradoresComponent implements OnInit {
  editable: boolean;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource([]);
  displayedColumns: string[] = ["indice","nombre", "departamento", "puesto", "accion"];
  colaboradores: Colaborador[] = [];
  constructor(
    private dialog: MatDialog,
    private colaboradoresService: ColaboradoresService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.editable = data.permission;
    });
    this.dataSource.paginator = this.paginator;
    this.getColaboradores();
  }
  onNewColaborador() {
    this.dialog
      .open(NuevoColaboradorDialogComponent, {
        minWidth: "35vw",
      })
      .afterClosed()
      .subscribe((response) => {
        if (response) {
          this.getColaboradores();
        }
      });
  }

  onEditarColaborador(colaborador: Colaborador) {
    this.dialog
      .open(NuevoColaboradorDialogComponent, {
        minWidth: "35vw",
        data: { colaborador },
      })
      .afterClosed()
      .subscribe((response) => {
        if (response) {
          this.getColaboradores();
        }
      });
  }

  getColaboradores() {
    this.colaboradoresService.getColaboradores().subscribe((res) => {
      console.log(res);
      if (res) {
        console.log(res);
        this.colaboradores = res;
        this.dataSource.data = this.colaboradores;
      }
    });
  }
  onDeleteColaborador(colaborador: Colaborador) {
    this.dialog
      .open(EliminarDialogComponent, {
        minWidth: "35vw",
        data: {
          title: "ELIMINAR COLABORADOR",
          content: `Desea eliminar el colaborador ${colaborador.nombre} ${colaborador.apellido}?`,
        },
      })
      .afterClosed()
      .subscribe((res) => {
        if (res) {
          this.colaboradoresService
            .deleteColaborador(colaborador.id)
            .subscribe((httpRes) => {
              if (httpRes.status === 202) {
                this.getColaboradores();
              }
            });
        }
      });
  }
}
