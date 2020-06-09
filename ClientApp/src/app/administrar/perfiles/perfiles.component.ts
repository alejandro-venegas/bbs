import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { rowAnimation } from '../../animations';

@Component({
  selector: 'app-perfiles',
  templateUrl: './perfiles.component.html',
  styleUrls: ['./perfiles.component.css'],
  animations: [rowAnimation],
})
export class PerfilesComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource([
    {
      nombre: 'Alejandro Venegas',
      departamento: 'Tecnologias de la informacion',
      rol: 'Gerente',
    },
  ]);
  constructor() {}
  displayedColumns: string[] = ['nombre', 'departamento', 'rol', 'accion'];
  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
  }
}
