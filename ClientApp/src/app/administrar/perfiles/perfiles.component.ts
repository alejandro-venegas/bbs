import { Component, OnInit, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { rowAnimation } from "../../animations";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-perfiles",
  templateUrl: "./perfiles.component.html",
  styleUrls: ["./perfiles.component.css"],
  animations: [rowAnimation],
})
export class PerfilesComponent implements OnInit {
  editable: boolean;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource([
    {
      nombre: "Alejandro Venegas",
      departamento: "Tecnologias de la informacion",
      rol: "Gerente",
    },
  ]);
  constructor(private route: ActivatedRoute) {}
  displayedColumns: string[] = ["nombre", "departamento", "rol", "accion"];
  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.editable = data.permission;
    });
    this.dataSource.paginator = this.paginator;
  }
}
