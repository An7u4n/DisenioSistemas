import { Component } from '@angular/core';
import { Router } from '@angular/router';

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

  constructor(private router: Router) {}

  loginSubmit(e: Event) {
    e.preventDefault();
    console.log("Form");
    if(this.loginForm.usuario == '!admin' && this.loginForm.contrasenia == 'admin') 
    {
      console.log("Login correcto");
      this.router.navigate(['/registrar-bedel']);
    }
  }
}