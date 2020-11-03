import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CasiIncidenteComponent } from './casi-incidente.component';
import {
  BrowserAnimationsModule,
  NoopAnimationsModule,
} from '@angular/platform-browser/animations';

describe('CasiIncidenteComponent', () => {
  let component: CasiIncidenteComponent;
  let fixture: ComponentFixture<CasiIncidenteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CasiIncidenteComponent],
      imports: [BrowserAnimationsModule, NoopAnimationsModule],
    }).compileComponents();
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
