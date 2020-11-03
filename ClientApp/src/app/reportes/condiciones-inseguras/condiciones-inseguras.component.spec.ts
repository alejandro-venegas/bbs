import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CondicionesInsegurasComponent } from './condiciones-inseguras.component';
import {
  BrowserAnimationsModule,
  NoopAnimationsModule,
} from '@angular/platform-browser/animations';

describe('CondicionesInsegurasComponent', () => {
  let component: CondicionesInsegurasComponent;
  let fixture: ComponentFixture<CondicionesInsegurasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CondicionesInsegurasComponent],
      imports: [BrowserAnimationsModule, NoopAnimationsModule],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CondicionesInsegurasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
