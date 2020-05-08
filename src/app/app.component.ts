import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ClientApp';
  baseUrl = environment.base_url;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get( this.baseUrl + '/weatherforecast').subscribe(res => console.log(res));
  }
}
