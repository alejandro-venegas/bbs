import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { HeaderService } from '../header/header.service';
import { slider } from '../animations';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css'],
  animations: [slider],
})
export class ReportesComponent implements OnInit {
  constructor(
    private headerService: HeaderService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.headerService.titleSubject.next('Nuevo Reporte');
    this.router.navigate(['incidente'], { relativeTo: this.activatedRoute });
  }
  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['number']
    );
  }
}
