import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { rowAnimation } from '../../animations';
import { MatDialog } from '@angular/material/dialog';
import { NuevoRolDialogComponent } from '../nuevo-rol-dialog/nuevo-rol-dialog.component';

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
  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  onNewRole() {
    this.dialog.open(NuevoRolDialogComponent, {
      minWidth: '35vw',
    });
  }
}
