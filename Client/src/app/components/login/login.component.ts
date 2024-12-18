import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../../services/login.service';
import { ToastrService } from 'ngx-toastr';

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

  constructor(private router: Router, private loginService: LoginService, private toastr:ToastrService) {}

  loginSubmit(e: Event) {
    console.log(this.loginForm)
    this.loginService.login(this.loginForm).subscribe({
      next: (response) => {
        this.loginService.procesarLoginResponse(response);
        this.toastr.success("Autenticación exitosa")
        this.router.navigate(['/home']);
      },
      error: (error) => {
        this.toastr.error(error,"Error")
        this.errorMessage =  `${error}`;
        console.error('Error en la solicitud de login:', error);
      }
    });
  }
}