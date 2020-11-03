import { Component, OnInit } from '@angular/core';
import { HeaderService } from '../header/header.service';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { slider } from '../animations';
import { AuthService } from '../shared/services/auth.service';

@Component({
  selector: 'app-administrar',
  templateUrl: './mantenimiento.component.html',
  styleUrls: ['./mantenimiento.component.css'],
  animations: [slider],
})
export class MantenimientoComponent implements OnInit {
  permittedViews = [];
  constructor(
    private headerService: HeaderService,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.headerService.titleSubject.next('Mantenimiento');
    this.authService.rolChangedSubject.subscribe((res) => {
      if (res) {
        this.permittedViews = res.rolVistas
          .map((rolVista) => rolVista.vista)
          .filter((vista) => vista.url.split('/')[1] === 'mantenimiento');
      }
    });
    this.getUserViews();
  }
  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['number']
    );
  }
  getUserViews() {
    this.authService.getCurrentUser().subscribe(
      (res) => {
        if (res) {
          this.permittedViews = res.rol.rolVistas
            .map((rolVista) => rolVista.vista)
            .filter((vista) => vista.url.split('/')[1] === 'mantenimiento');

          this.router.navigate([this.permittedViews[0].url], {
            relativeTo: this.route,
          });
        }
      },
      (error) => {
        this.router.navigate(['login']);
      }
    );
  }
}
