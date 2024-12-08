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
    usuario: '',
    contrasenia: ''
  };

  constructor(private router: Router, private loginService: LoginService) {}

  loginSubmit(e: Event) {
    e.preventDefault();
    if(this.loginForm.usuario == '!admin' && this.loginForm.contrasenia == 'admin') 
    {
      this.loginService.login();
      this.router.navigate(['/home']);
    }
  }
}