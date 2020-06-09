import { Component, OnInit } from '@angular/core';
import { HeaderService } from '../header/header.service';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { slider } from '../animations';

@Component({
  selector: 'app-graficos',
  templateUrl: './graficos.component.html',
  styleUrls: ['./graficos.component.css'],
  animations: [slider],
})
export class GraficosComponent implements OnInit {
  constructor(
    private headerService: HeaderService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.router.navigate(['filtros'], { relativeTo: this.route });
    this.headerService.titleSubject.next('Graficos');
  }
  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['number']
    );
  }
}
