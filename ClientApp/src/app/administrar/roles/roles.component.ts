import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { rowAnimation } from '../../animations';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css'],
  animations: [rowAnimation],
})
export class RolesComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource([
    { nombre: 'Gerente' },
    { nombre: 'Colaborador' },
    { nombre: 'Gerente' },
    { nombre: 'Colaborador' },
    { nombre: 'Gerente' },
    { nombre: 'Colaborador' },
    { nombre: 'Gerente' },
    { nombre: 'Colaborador' },
  ]);
  displayedColumns: string[] = ['nombre', 'accion'];
  constructor() {}

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
  }
}
