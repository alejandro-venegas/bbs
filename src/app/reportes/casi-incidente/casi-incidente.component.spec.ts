import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CasiIncidenteComponent } from './casi-incidente.component';

describe('CasiIncidenteComponent', () => {
  let component: CasiIncidenteComponent;
  let fixture: ComponentFixture<CasiIncidenteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CasiIncidenteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CasiIncidenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
