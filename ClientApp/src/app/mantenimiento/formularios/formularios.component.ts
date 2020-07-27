import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";

import { rowAnimation, treeAnimation } from "../../animations";

import { NestedTreeControl } from "@angular/cdk/tree";
import { MatTreeNestedDataSource } from "@angular/material/tree";
import { BehaviorSubject } from "rxjs";
import { SelectNode, TreeDataSource } from "./tree-datasource";
import { FormulariosService } from "../../shared/services/formularios.service";
import { MatDialog } from "@angular/material/dialog";
import { EliminarDialogComponent } from "../../shared/dialogs/eliminar-dialog/eliminar-dialog.component";
import { ActivatedRoute } from "@angular/router";

/**
 * @title Tree with nested nodes
 */
@Component({
  selector: "app-formularios",
  templateUrl: "./formularios.component.html",
  styleUrls: ["./formularios.component.css"],
  animations: [rowAnimation, treeAnimation],
})
export class FormulariosComponent implements OnInit {
  editable: boolean;
  isValid = true;
  TREE_DATA: SelectNode[] = [
    {
      nombre: "Actividades",
      selectId: "1",
      children: [],
    },
    {
      nombre: "Areas",
      selectId: "2",
      children: [],
    },
    {
      nombre: "Casualidades",
      selectId: "3",
      children: [],
    },
    {
      nombre: "Causas Basicas",
      selectId: "4",
      children: [],
    },
    {
      nombre: "Causas Inmediatas",
      selectId: "5",
      children: [],
    },
    {
      nombre: "Clasificaciones",
      selectId: "6",
      children: [],
    },
    {
      nombre: "Comportamientos",
      selectId: "7",
      children: [],
    },
    {
      nombre: "Efectos",
      selectId: "8",
      children: [],
    },
    {
      nombre: "Factor Riesgo",
      selectId: "9",
      children: [],
    },
    {
      nombre: "Generos",
      selectId: "10",
      children: [],
    },
    {
      nombre: "Indicadores de Riesgo",
      selectId: "11",
      children: [],
    },
    {
      nombre: "Jornadas",
      selectId: "12",
      children: [],
    },
    {
      nombre: "Observados",
      selectId: "13",
      children: [],
    },
    {
      nombre: "Partes del cuerpo",
      selectId: "14",
      children: [],
    },
    {
      nombre: "Procesos",
      selectId: "15",
      children: [],
    },
    {
      nombre: "Riesgos",
      selectId: "16",
      children: [],
    },
    {
      nombre: "Tipos de Comportamiento",
      selectId: "17",
      children: [],
    },
    {
      nombre: "Tipos de Observado",
      selectId: "18",
      children: [],
    },
    {
      nombre: "Turnos",
      selectId: "19",
      children: [],
    },
  ];

  treeControl = new NestedTreeControl<SelectNode>((node) => node.children);
  dataSource = new TreeDataSource(this.treeControl, []);
  constructor(
    private formulariosService: FormulariosService,
    private dialog: MatDialog,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.editable = data.permission;
    });
    this.initializeData();
  }

  hasChild = (_: number, node: SelectNode) => !!node.children;
  hasNoChild = (_: number, node: SelectNode) => !!!node.children;
  hasNoContent = (_: number, node: SelectNode) => !!!node.nombre;
  isUpdate = (_: number, node: SelectNode) => node.editMode;

  addNewItem(nombre: string, parentNode: SelectNode, optionId: string = null) {
    this.treeControl.expand(parentNode);
    this.dataSource.add(
      { nombre, optionId, selectId: parentNode.selectId },
      parentNode
    );
  }

  onUpdateItem(nombre: string, node: SelectNode) {
    if (nombre) {
      if (nombre.length <= 75) {
        const parent = this.dataSource.data.find(
          (parentNode) => parentNode.selectId == node.selectId
        );

        if (parent) {
          this.formulariosService
            .updateSelect({
              nombre,
              selectId: node.selectId,
              optionId: node.optionId,
            })
            .subscribe((res) => {
              if (res.status === 201) {
                node.nombre = nombre;
                this.dataSource.updateItem(node);
              }

              this.dataSource.updateItem(node);
            });
        }
      } else {
        this.isValid = false;
      }
    } else {
      this.dataSource.updateItem(node);
    }
  }

  updateItem(node: SelectNode) {
    console.log(node);
    this.dataSource.updateNode(node);
  }
  cancelUpdate(node: SelectNode) {
    this.dataSource.updateItem(node);
  }

  remove(node: SelectNode) {
    if (node.nombre && !node.editMode) {
      this.dialog
        .open(EliminarDialogComponent, {
          minWidth: "35vw",
          data: {
            title: "ELIMINAR COLABORADOR",
            content: `¿Desea eliminar el colaborador ${node.nombre}?`,
          },
        })
        .afterClosed()
        .subscribe((res) => {
          if (res) {
            this.formulariosService.deleteSelect(node).subscribe((res) => {
              if (res.status === 202) {
                this.dataSource.remove(node);
              }
            });
          }
        });
    } else {
      this.dataSource.remove(node);
    }
    this.isValid = true;
  }

  initializeData() {
    this.formulariosService.getSelectOptions().subscribe((res) => {
      const data = this.TREE_DATA;
      for (const option of res) {
        let parentNode = data.find((node) => node.selectId == option.selectId);
        if (parentNode) {
          parentNode.children.push(option);
        }
      }
      this.dataSource = new TreeDataSource(this.treeControl, data);
    });
  }
  onAgregarNewItem(nombre: string, node: SelectNode) {
    if (nombre) {
      if (nombre.length <= 75) {
        const parent = this.dataSource.data.find(
          (parentNode) => parentNode.selectId == node.selectId
        );

        if (parent) {
          this.formulariosService
            .insertSelect({ nombre, selectId: node.selectId })
            .subscribe((res) => {
              if (res.status === 200) {
                this.addNewItem(res.body.nombre, parent, res.body.id);
              }

              this.remove(node);
            });
        }
      } else {
        this.isValid = false;
      }
    } else {
      this.remove(node);
    }
  }
}
