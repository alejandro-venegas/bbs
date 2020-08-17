import { Component, OnInit, ViewChild } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";
import { Rol } from "../../shared/models/rol.model";
import { rowAnimation } from "../../animations";
import { BitacoraService } from "../bitacora.service";
import { MatPaginator } from "@angular/material/paginator";

@Component({
  selector: "app-bitacora",
  templateUrl: "./bitacora.component.html",
  styleUrls: ["./bitacora.component.scss"],
  animations: [rowAnimation],
})
export class BitacoraComponent implements OnInit {
  dataSource = new MatTableDataSource<any>();
  displayedColumns: string[] = ["fecha", "usuario", "descripcion"];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  constructor(private bitacoraService: BitacoraService) {}

  ngOnInit(): void {
    this.getBitacora();
    this.dataSource.paginator = this.paginator;
  }

  getBitacora() {
    this.bitacoraService.getBitacora().subscribe((res) => {
      this.dataSource.data = res;
      console.log(res);
    });
  }
}
