import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  error: string = '';
  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  onIngresar(username: string, password: string) {
    this.authService.logIn(username, password).subscribe(
      (value) => {
        this.router.navigate(['reportes']);
      },
      (error) => {
        console.log(error);
        if (error.status === 401) {
          this.error = 'Credenciales invalidas';
        }
      }
    );
  }
}
