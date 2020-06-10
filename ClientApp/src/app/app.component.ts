import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { verticalSlider } from './animations';
import { TestServiceService } from './test-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [verticalSlider],
})
export class AppComponent implements OnInit {
  title = 'ClientApp';
  constructor(private testService: TestServiceService) {}

  ngOnInit() {
    this.testService.getTestValues();
  }

  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['module']
    );
  }
}
