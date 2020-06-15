import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

import { rowAnimation, treeAnimation } from '../../animations';

import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { BehaviorSubject } from 'rxjs';
import { SelectNode, TreeDataSource } from './tree-datasource';
import { FormulariosService } from '../../shared/services/formularios.service';

/**
 * @title Tree with nested nodes
 */
@Component({
  selector: 'app-formularios',
  templateUrl: './formularios.component.html',
  styleUrls: ['./formularios.component.css'],
  animations: [rowAnimation, treeAnimation],
})
export class FormulariosComponent implements OnInit {
  TREE_DATA: SelectNode[] = [
    {
      nombre: 'Actividades',
      selectId: '1',
      children: [],
    },
    {
      nombre: 'Areas',
      selectId: '2',
      children: [],
    },
    {
      nombre: 'Casualidades',
      selectId: '3',
      children: [],
    },
    {
      nombre: 'Causas Basicas',
      selectId: '4',
      children: [],
    },
    {
      nombre: 'Causas Inmediatas',
      selectId: '5',
      children: [],
    },
    {
      nombre: 'Clasificaciones',
      selectId: '6',
      children: [],
    },
    {
      nombre: 'Comportamientos',
      selectId: '7',
      children: [],
    },
    {
      nombre: 'Efectos',
      selectId: '8',
      children: [],
    },
    {
      nombre: 'Factor Riesgo',
      selectId: '9',
      children: [],
    },
    {
      nombre: 'Generos',
      selectId: '10',
      children: [],
    },
    {
      nombre: 'Indicadores de Riesgo',
      selectId: '11',
      children: [],
    },
    {
      nombre: 'Jornadas',
      selectId: '12',
      children: [],
    },
    {
      nombre: 'Observados',
      selectId: '13',
      children: [],
    },
    {
      nombre: 'Partes del cuerpo',
      selectId: '14',
      children: [],
    },
    {
      nombre: 'Procesos',
      selectId: '15',
      children: [],
    },
    {
      nombre: 'Riesgos',
      selectId: '16',
      children: [],
    },
    {
      nombre: 'Tipos de Comportamiento',
      selectId: '17',
      children: [],
    },
    {
      nombre: 'Tipos de Observado',
      selectId: '18',
      children: [],
    },
    {
      nombre: 'Turnos',
      selectId: '19',
      children: [],
    },
  ];

  treeControl = new NestedTreeControl<SelectNode>((node) => node.children);
  dataSource = new TreeDataSource(this.treeControl, []);
  constructor(private formulariosService: FormulariosService) {}

  ngOnInit() {
    this.initializeData();
  }

  hasChild = (_: number, node: SelectNode) => !!node.children;
  hasNoChild = (_: number, node: SelectNode) => !!!node.children;
  hasNoContent = (_: number, node: SelectNode) => !!!node.nombre;

  addNewItem(nombre: string, parentNode: SelectNode) {
    this.treeControl.expand(parentNode);
    this.dataSource.add({ nombre, selectId: parentNode.selectId }, parentNode);
  }
  remove(node: SelectNode) {
    if (node.nombre) {
      this.formulariosService.deleteSelect(node).subscribe((res) => {
        if (res.status === 202) {
          this.dataSource.remove(node);
        }
      });
    } else {
      this.dataSource.remove(node);
    }
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
      const parent = this.dataSource.data.find(
        (parentNode) => parentNode.selectId == node.selectId
      );

      if (parent) {
        this.formulariosService
          .insertSelect({ nombre, selectId: node.selectId })
          .subscribe((res) => {
            if (res.status === 201) {
              this.addNewItem(nombre, parent);
            }

            this.remove(node);
          });
      }
    }
  }
}
