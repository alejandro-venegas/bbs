import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BbsComponent } from './bbs.component';
import {
  BrowserAnimationsModule,
  NoopAnimationsModule,
} from '@angular/platform-browser/animations';

describe('BbsComponent', () => {
  let component: BbsComponent;
  let fixture: ComponentFixture<BbsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [BbsComponent],
      imports: [BrowserAnimationsModule, NoopAnimationsModule],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BbsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
