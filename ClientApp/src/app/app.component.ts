import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { verticalSlider } from './animations';

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

  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['module']
    );
  }
}
