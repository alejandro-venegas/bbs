import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoDepartamentoDialogComponent } from './nuevo-departamento-dialog.component';

describe('NuevoDepartamentoDialogComponent', () => {
  let component: NuevoDepartamentoDialogComponent;
  let fixture: ComponentFixture<NuevoDepartamentoDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NuevoDepartamentoDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NuevoDepartamentoDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
