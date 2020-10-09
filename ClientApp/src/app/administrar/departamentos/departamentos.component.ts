import { Component, OnInit, ViewChild } from "@angular/core";
import { rowAnimation } from "../../animations";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { DepartamentosService } from "./departamentos.service";
import { Departamento } from "../../shared/models/departamento.model";
import { NuevoColaboradorDialogComponent } from "../colaboradores/nuevo-colaborador-dialog/nuevo-colaborador-dialog.component";
import { MatDialog } from "@angular/material/dialog";
import { NuevoDepartamentoDialogComponent } from "./nuevo-departamento-dialog/nuevo-departamento-dialog.component";
import { Rol } from "../../shared/models/rol.model";
import { EliminarDialogComponent } from "../../shared/dialogs/eliminar-dialog/eliminar-dialog.component";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-departamentos",
  templateUrl: "./departamentos.component.html",
  styleUrls: ["./departamentos.component.css"],
  animations: [rowAnimation],
})
export class DepartamentosComponent implements OnInit {
  editable: boolean;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource([]);
  departamentos: Departamento[];
  displayedColumns: string[] = ["indice","nombre", "gerente", "accion"];
  constructor(
    private departamentosService: DepartamentosService,
    private dialog: MatDialog,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.editable = data.permission;
    });
    this.dataSource.paginator = this.paginator;
    this.getDepartamentos();
  }

  getDepartamentos() {
    this.departamentosService.getDepartamentos().subscribe((res) => {
      this.departamentos = res;
      this.dataSource.data = this.departamentos;
    });
  }
  onAgregar() {
    this.dialog
      .open(NuevoDepartamentoDialogComponent, {
        minWidth: "35vw",
      })
      .afterClosed()
      .subscribe((response) => {
        if (response) {
          this.getDepartamentos();
        }
      });
  }
  onUpdateDepartamento(departamento: Departamento) {
    this.dialog
      .open(NuevoDepartamentoDialogComponent, {
        minWidth: "35vw",
        data: { departamento },
      })
      .afterClosed()
      .subscribe((response) => {
        if (response) {
          this.getDepartamentos();
        }
      });
  }
  onDeleteDepartamento(departamento: Departamento) {
    this.dialog
      .open(EliminarDialogComponent, {
        minWidth: "35vw",
        data: {
          title: "ELIMINAR DEPARTAMENTO",
          content: `Desea eliminar el departamento ${departamento.nombre}?`,
        },
      })
      .afterClosed()
      .subscribe((res) => {
        if (res) {
          this.departamentosService
            .deleteDepartamento(departamento.id)
            .subscribe((httpRes) => {
              if (httpRes.status === 202) {
                this.getDepartamentos();
              }
            });
        }
      });
  }
}
