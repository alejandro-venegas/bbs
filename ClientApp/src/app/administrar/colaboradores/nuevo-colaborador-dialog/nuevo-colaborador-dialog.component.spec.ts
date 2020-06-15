import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoColaboradorDialogComponent } from './nuevo-colaborador-dialog.component';

describe('NuevoColaboradorDialogComponent', () => {
  let component: NuevoColaboradorDialogComponent;
  let fixture: ComponentFixture<NuevoColaboradorDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NuevoColaboradorDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NuevoColaboradorDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
