import {
  Directive,
  ElementRef,
  EventEmitter,
  HostListener,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { SelectNode } from '../../mantenimiento/formularios/tree-datasource';

@Directive({
  selector: '[appAutofocus]',
})
export class AutofocusDirective implements OnInit {
  @Output() focusOut = new EventEmitter<SelectNode>();
  constructor(private el: ElementRef) {}
  ngOnInit() {
    this.el.nativeElement.focus();
  }

  @HostListener('focusout', ['$event'])
  onFocusOut(event) {
    console.log(event);
    if (
      !event.relatedTarget ||
      (event.relatedTarget &&
        event.relatedTarget.textContent &&
        event.relatedTarget.textContent.toLowerCase() !== 'done')
    ) {
      this.focusOut.emit();
    }
  }
}
