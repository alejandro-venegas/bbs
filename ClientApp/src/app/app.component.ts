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
  animations: [verticalSlider],
})
export class AppComponent implements OnInit {
  title = "SHE";
  smallNav = false;
  useSmallNav: boolean;
  constructor(
    private testService: TestServiceService,
    private screenService: ScreenService
  ) {}
  ngOnInit() {
    this.testService.getTestValues();
    this.screenService.screenWidthSubject.subscribe((res) => {
      this.useSmallNav = !(
        res &&
        res.breakpoints &&
        res.breakpoints["(min-width: 1110px)"]
      );
      this.smallNav = this.useSmallNav;
    });
    this.screenService.initializeBreakPointsSubject();
  }

  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData["module"]
    );
  }

  onNavToggledEvent() {
    if (!this.useSmallNav) {
      this.smallNav = !this.smallNav;
    }
  }
}
