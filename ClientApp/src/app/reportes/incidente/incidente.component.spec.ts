import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncidenteComponent } from './incidente.component';
import {
  BrowserAnimationsModule,
  NoopAnimationsModule,
} from '@angular/platform-browser/animations';

describe('IncidenteComponent', () => {
  let component: IncidenteComponent;
  let fixture: ComponentFixture<IncidenteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [IncidenteComponent],
      imports: [BrowserAnimationsModule, NoopAnimationsModule],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncidenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
