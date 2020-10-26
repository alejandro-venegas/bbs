import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import {
  ActivatedRoute,
  NavigationEnd,
  Router,
  RouterOutlet,
} from '@angular/router';
import { HeaderService } from '../header/header.service';
import { slider } from '../animations';
import { AuthService } from '../shared/services/auth.service';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css'],
  animations: [slider],
})
export class ReportesComponent implements OnInit {
  permittedViews = [];
  constructor(
    private headerService: HeaderService,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.headerService.titleSubject.next('Nuevo Reporte');
    this.getUserViews();
  }
  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['number']
    );
  }
  getUserViews() {
    this.authService.getCurrentUserRol().subscribe((res) => {
      if (res) {
        this.permittedViews = res.rolVistas
          .map((rolVista) => rolVista.vista)
          .filter((vista) => vista.url.split('/')[1] === 'reportes');

        this.router.navigate([this.permittedViews[0].url], {
          relativeTo: this.route,
        });
      }
    });
  }
}
