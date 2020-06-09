import { Component, OnInit } from '@angular/core';
import { HeaderService } from '../header/header.service';
import { RouterOutlet } from '@angular/router';
import { slider } from '../animations';

@Component({
  selector: 'app-roles-perfiles',
  templateUrl: './administrar.component.html',
  styleUrls: ['./administrar.component.css'],
  animations: [slider],
})
export class AdministrarComponent implements OnInit {
  constructor(private headerService: HeaderService) {}

  ngOnInit(): void {
    this.headerService.titleSubject.next('Administrar');
  }
  prepareRoute(outlet: RouterOutlet) {
    return (
      outlet && outlet.activatedRouteData && outlet.activatedRouteData['module']
    );
  }
}
