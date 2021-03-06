import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';
import { ScreenService } from '../shared/services/screen.service';

@Component({
  selector: 'app-left-nav',
  templateUrl: './left-nav.component.html',
  styleUrls: ['./left-nav.component.css'],
})
export class LeftNavComponent implements OnInit {
  @Output() toggleNav = new EventEmitter();
  permittedViews: any[] = [];
  isMobileScreen: boolean = false;
  constructor(
    private authService: AuthService,
    private screenService: ScreenService
  ) {}

  ngOnInit(): void {
    this.getUserViews();
    this.subscribeScreenWidthSubject();
  }

  onLogoClick() {
    this.toggleNav.emit();
  }

  subscribeScreenWidthSubject() {
    this.screenService.screenWidthSubject.subscribe((res) => {
      this.isMobileScreen = res && res.breakpoints['(max-width: 600px)'];
    });
  }

  getUserViews() {
    this.authService.rolChangedSubject.subscribe((res) => {
      if (res) {
        this.permittedViews = res.rolVistas.map(
          (rolVista) => rolVista.vista.url.split('/')[1]
        );
      }
    });
  }

  isPermitted(nombre: string) {
    return this.permittedViews.find((value) => value === nombre);
  }

  onLogOut() {
    this.authService.logOut();
  }
}
