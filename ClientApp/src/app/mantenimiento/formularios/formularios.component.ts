import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Rol } from '../../administrar/roles/rol.model';
import { rowAnimation } from '../../animations';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-formularios',
  templateUrl: './formularios.component.html',
  styleUrls: ['./formularios.component.css'],
  animations: [rowAnimation],
})
export class FormulariosComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['nombre', 'creador', 'accion'];
  dataSource = new MatTableDataSource([
    { nombre: 'Incidente', creador: 'Administrador' },
    { nombre: 'Casi Incidente', creador: 'Administrador' },
    { nombre: 'BBS', creador: 'Administrador' },
    { nombre: 'Condiciones Inseguras', creador: 'Administrador' },
  ]);
  constructor() {}

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
  }
}
