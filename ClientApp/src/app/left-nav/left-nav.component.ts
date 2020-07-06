import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { AuthService } from "../shared/services/auth.service";

@Component({
  selector: "app-left-nav",
  templateUrl: "./left-nav.component.html",
  styleUrls: ["./left-nav.component.css"],
})
export class LeftNavComponent implements OnInit {
  @Output() toggleNav = new EventEmitter();
  permittedViews: any[] = [];
  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.getUserViews();
    this.authService.rolChangedSubject.subscribe((res) => this.getUserViews());
  }

  onLogoClick() {
    this.toggleNav.emit();
  }

  getUserViews() {
    this.authService.getCurrentUserRol().subscribe((res) => {
      if (res) {
        console.log(res);
        this.permittedViews = res.rolVistas.map((rolVista) =>
          rolVista.vista.nombre.toLowerCase()
        );
        console.log(this.permittedViews);
      }
    });
  }

  isPermitted(nombre: string) {
    return this.permittedViews.find((value) => value === nombre);
  }
}
