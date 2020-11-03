import { Component, OnInit } from '@angular/core';
import { HeaderService } from '../header/header.service';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { slider, verticalSlider } from '../animations';
import { AuthService } from '../shared/services/auth.service';

@Component({
  selector: 'app-roles-perfiles',
  templateUrl: './administrar.component.html',
  styleUrls: ['./administrar.component.css'],
  animations: [slider],
})
export class AdministrarComponent implements OnInit {
  permittedViews = [];
  constructor(
    private headerService: HeaderService,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.headerService.titleSubject.next('Administrar');
    this.authService.rolChangedSubject.subscribe((res) => {
      if (res) {
        this.permittedViews = res.rolVistas
          .map((rolVista) => rolVista.vista)
          .filter((vista) => vista.url.split('/')[1] === 'administrar');
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
            .filter((vista) => vista.url.split('/')[1] === 'administrar');

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
