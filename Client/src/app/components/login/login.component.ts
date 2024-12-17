import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  hide = true;
  loginForm = {
    name: '',
    password: ''
  };
  errorMessage: string = "";

  constructor(private router: Router, private loginService: LoginService) {}

  loginSubmit(e: Event) {
    console.log(this.loginForm)
    this.loginService.login(this.loginForm).subscribe({
      next: (response) => {
        this.loginService.procesarLoginResponse(response);
      },
      error: (error) => {
        this.errorMessage =  `${error}`;
        console.error('Error en la solicitud de login:', error);
      }
    });
  }
}