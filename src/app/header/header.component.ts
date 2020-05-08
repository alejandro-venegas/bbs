import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HeaderService } from './header.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  title: string;
  constructor(private headerService: HeaderService) {}

  ngOnInit(): void {
    this.headerService.titleSubject.subscribe(value => (this.title = value));
  }
}
