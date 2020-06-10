import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-eliminar-dialog',
  templateUrl: './eliminar-dialog.component.html',
  styleUrls: ['./eliminar-dialog.component.css'],
})
export class EliminarDialogComponent implements OnInit {
  constructor(
    private dialogRef: MatDialogRef<EliminarDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {}

  onDelete() {
    this.dialogRef.close(true);
  }
}
