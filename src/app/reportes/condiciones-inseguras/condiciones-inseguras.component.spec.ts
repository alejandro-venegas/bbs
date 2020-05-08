import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CondicionesInsegurasComponent } from './condiciones-inseguras.component';

describe('CondicionesInsegurasComponent', () => {
  let component: CondicionesInsegurasComponent;
  let fixture: ComponentFixture<CondicionesInsegurasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CondicionesInsegurasComponent ]
    })
    .compileComponents();
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
