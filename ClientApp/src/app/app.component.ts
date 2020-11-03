import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { verticalSlider } from './animations';
import { TestServiceService } from './test-service.service';
import { BreakpointObserver } from '@angular/cdk/layout';
import { ScreenService } from './shared/services/screen.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [verticalSlider],
})
export class AppComponent implements OnInit {
  title = 'ClientApp';

  constructor() {}

  ngOnInit() {}
}
