import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { rowAnimation, verticalSlider } from './animations';
import { TestServiceService } from './test-service.service';
import { BreakpointObserver } from '@angular/cdk/layout';
import { ScreenService } from './shared/services/screen.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [rowAnimation],
})
export class AppComponent implements OnInit {
  title = 'ClientApp';

  constructor() {}

  ngOnInit() {}
  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['module']
    );
  }
}
