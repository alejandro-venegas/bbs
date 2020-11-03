import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { rowAnimation } from '../../animations';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../shared/services/auth.service';
import { NuevoDepartamentoDialogComponent } from '../departamentos/nuevo-departamento-dialog/nuevo-departamento-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { NuevoUsuarioDialogComponent } from './nuevo-usuario-dialog/nuevo-usuario-dialog.component';

@Component({
  selector: 'app-perfiles',
  templateUrl: './perfiles.component.html',
  styleUrls: ['./perfiles.component.css'],
  animations: [rowAnimation],
})
export class PerfilesComponent implements OnInit {
  editable: boolean;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource([]);
  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private dialog: MatDialog
  ) {}
  displayedColumns: string[] = [
    'indice',
    'nombre',
    'departamento',
    'rol',
    'accion',
  ];
  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.editable = data.permission;
    });
    this.dataSource.paginator = this.paginator;
    this.getUsers();
  }
  getUsers() {
    this.authService.getUsers().subscribe((value) => {
      console.log(value);
      this.dataSource = new MatTableDataSource<any>(value);
    });
  }

  onCrearUsuario() {
    this.dialog
      .open(NuevoUsuarioDialogComponent, {
        minWidth: '35vw',
      })
      .afterClosed()
      .subscribe((response) => {
        if (response) {
          this.getUsers();
        }
      });
  }
}
