import { Component, OnInit } from '@angular/core';
import { TestServiceService } from '../test-service.service';
import { ScreenService } from '../shared/services/screen.service';
import { RouterOutlet } from '@angular/router';
import { verticalSlider } from '../animations';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
  animations: [verticalSlider],
})
export class LayoutComponent implements OnInit {
  smallNav = false;
  useSmallNav: boolean;
  constructor(
    private testService: TestServiceService,
    private screenService: ScreenService
  ) {}

  ngOnInit() {
    this.screenService.screenWidthSubject.subscribe((res) => {
      this.useSmallNav = !(
        res &&
        res.breakpoints &&
        res.breakpoints['(min-width: 1110px)']
      );
      this.smallNav = this.useSmallNav;
    });
    this.screenService.initializeBreakPointsSubject();
  }

  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['module']
    );
  }

  onNavToggledEvent() {
    if (!this.useSmallNav) {
      this.smallNav = !this.smallNav;
    }
  }
}
