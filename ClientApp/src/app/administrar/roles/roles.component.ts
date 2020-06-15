import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { rowAnimation } from '../../animations';
import { MatDialog } from '@angular/material/dialog';
import { NuevoRolDialogComponent } from '../nuevo-rol-dialog/nuevo-rol-dialog.component';
import { RolesService } from './roles.service';
import { Rol } from './rol.model';
import { EliminarDialogComponent } from '../../shared/dialogs/eliminar-dialog/eliminar-dialog.component';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css'],
  animations: [rowAnimation],
})
export class RolesComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource<Rol>();
  displayedColumns: string[] = ['nombre', 'accion'];
  constructor(private dialog: MatDialog, private rolesService: RolesService) {}

  ngOnInit(): void {
    this.getRoles();
  }

  onNewRole() {
    this.dialog
      .open(NuevoRolDialogComponent, {
        minWidth: '35vw',
      })
      .afterClosed()
      .subscribe((response) => {
        if (response) {
          this.getRoles();
        }
      });
  }

  onEditRol(rol: Rol) {
    this.dialog
      .open(NuevoRolDialogComponent, {
        minWidth: '35vw',
        data: { rol },
      })
      .afterClosed()
      .subscribe((response) => {
        if (response) {
          this.getRoles();
        }
      });
  }

  getRoles() {
    this.rolesService.getRoles().subscribe((res) => {
      this.dataSource = new MatTableDataSource(res);
      this.dataSource.paginator = this.paginator;
    });
  }

  onDeleteRol(rol: Rol) {
    this.dialog
      .open(EliminarDialogComponent, {
        minWidth: '35vw',
        data: {
          title: 'ELIMINAR ROL',
          content: `Desea eliminar el rol ${rol.nombreRol}?`,
        },
      })
      .afterClosed()
      .subscribe((res) => {
        if (res) {
          this.rolesService.deleteRole(rol.id).subscribe((httpRes) => {
            console.log(res);
            if (httpRes.status === 202) {
              this.getRoles();
            }
          });
        }
      });
  }
}
