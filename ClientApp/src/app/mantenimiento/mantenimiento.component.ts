import { Component, OnInit } from '@angular/core';
import { HeaderService } from '../header/header.service';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { slider } from '../animations';

@Component({
  selector: 'app-administrar',
  templateUrl: './mantenimiento.component.html',
  styleUrls: ['./mantenimiento.component.css'],
  animations: [slider],
})
export class MantenimientoComponent implements OnInit {
  constructor(
    private headerService: HeaderService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.headerService.titleSubject.next('Mantenimiento');
    this.router.navigate(['formularios'], { relativeTo: this.route });
  }
  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['number']
    );
  }
}
