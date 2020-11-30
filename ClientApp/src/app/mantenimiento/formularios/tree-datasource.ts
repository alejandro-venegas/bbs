import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { MatTreeNestedDataSource, MatTree } from '@angular/material/tree';

/**
 * Food data with nested structure.
 * Each node has a nombre and an optional list of children.
 */
export interface SelectNode {
  nombre: string;
  selectId: string;
  optionId?: string;
  children?: SelectNode[];
  editMode?: boolean;
  childOptions?: SelectNode[];
  parentOptionId?: string;
  isAncestor?: boolean;
  id?: string;
}

export class TreeDataSource extends MatTreeNestedDataSource<SelectNode> {
  constructor(
    private treeControl: NestedTreeControl<SelectNode>,
    intialData: SelectNode[]
  ) {
    super();
    this._data.next(intialData);
  }

  /** Add node as child of parent */
  public add(node: SelectNode, parent: SelectNode) {
    // add dummy root so we only have to deal with `SelectNode`s
    const newTreeData = {
      nombre: 'Dummy Root',
      selectId: '',
      children: this.data,
    };
    this._add(node, parent, newTreeData);
    this.data = newTreeData.children;
  }

  public updateNode(node: SelectNode) {
    const newTreeData = {
      nombre: 'Dummy Root',
      selectId: '',
      children: this.data,
    };
    this._updateNode(node, newTreeData);
    this.data = newTreeData.children;
  }

  public updateItem(node: SelectNode) {
    const newTreeData = {
      nombre: 'Dummy Root',
      selectId: '',
      children: this.data,
    };
    this._updateItem(node, newTreeData);
    this.data = newTreeData.children;
  }

  /** Remove node from tree */
  public remove(node: SelectNode) {
    const newTreeData = {
      nombre: 'Dummy Root',
      selectId: '',
      children: this.data,
    };
    this._remove(node, newTreeData);
    this.data = newTreeData.children;
  }

  /*
   * For immutable update patterns, have a look at:
   * https://redux.js.org/recipes/structuring-reducers/immutable-update-patterns/
   */

  protected _add(newNode: SelectNode, parent: SelectNode, tree: SelectNode) {
    if (tree === parent) {
      console.log(
        `replacing children array of '${parent.nombre}', adding ${newNode.nombre}`
      );
      tree.children = [...tree.children!, newNode];
      this.treeControl.expand(tree);
      return true;
    }
    if (!tree.children) {
      console.log(`reached leaf node '${tree.nombre}', backing out`);
      return false;
    }
    return this.update(tree, this._add.bind(this, newNode, parent));
  }

  _updateNode(node: SelectNode, tree: SelectNode): boolean {
    if (!tree.children) {
      return false;
    }
    const i = tree.children.indexOf(node);
    node.editMode = true;
    if (i > -1) {
      tree.children = [
        ...tree.children.slice(0, i),
        node,
        ...tree.children.slice(i + 1),
      ];
      console.log(`found ${node.nombre}, removing it from`, tree);
      return true;
    }
    return this.update(tree, this._updateNode.bind(this, node));
  }

  _updateItem(node: SelectNode, tree: SelectNode): boolean {
    if (!tree.children) {
      return false;
    }
    const i = tree.children.indexOf(node);
    node.editMode = false;
    if (i > -1) {
      tree.children = [
        ...tree.children.slice(0, i),
        node,
        ...tree.children.slice(i + 1),
      ];
      return true;
    }
    return this.update(tree, this._updateItem.bind(this, node));
  }

  _remove(node: SelectNode, tree: SelectNode): boolean {
    if (!tree.children) {
      return false;
    }
    const i = tree.children.indexOf(node);
    if (i > -1) {
      tree.children = [
        ...tree.children.slice(0, i),
        ...tree.children.slice(i + 1),
      ];
      this.treeControl.collapse(node);
      console.log(`found ${node.nombre}, removing it from`, tree);
      return true;
    }
    return this.update(tree, this._remove.bind(this, node));
  }

  protected update(tree: SelectNode, predicate: (n: SelectNode) => boolean) {
    let updatedTree: SelectNode, updatedIndex: number;

    tree.children!.find((node, i) => {
      if (predicate(node)) {
        console.log(`creating new node for '${node.nombre}'`);
        updatedTree = { ...node };
        updatedIndex = i;
        this.moveExpansionState(node, updatedTree);
        return true;
      }
      return false;
    });

    if (updatedTree!) {
      console.log(`replacing node '${tree.children![updatedIndex!].nombre}'`);
      tree.children![updatedIndex!] = updatedTree!;
      return true;
    }
    return false;
  }

  moveExpansionState(from: SelectNode, to: SelectNode) {
    if (this.treeControl.isExpanded(from)) {
      console.log(
        `'${from.nombre}' was expanded, setting expanded on new node`
      );
      this.treeControl.collapse(from);
      this.treeControl.expand(to);
    }
  }
}
