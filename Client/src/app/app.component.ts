import { Component } from '@angular/core';
import { LoginService } from './services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  title = 'Client';

  constructor(private _loginService:LoginService, private router:Router){}

  isAuthenticated() : boolean{
    return this._loginService.estaAutenticado()
  }

  logout() {
    this._loginService.logout()
    this.router.navigate(['login'])
    }

}
