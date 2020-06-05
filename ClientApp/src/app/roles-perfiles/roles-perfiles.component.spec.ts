import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RolesPerfilesComponent } from './roles-perfiles.component';

describe('RolesPerfilesComponent', () => {
  let component: RolesPerfilesComponent;
  let fixture: ComponentFixture<RolesPerfilesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RolesPerfilesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RolesPerfilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
