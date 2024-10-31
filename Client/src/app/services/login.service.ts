import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private autenticado: boolean = false;

  estaAutenticado(): boolean {
    return this.autenticado;
  }

  login() {
    this.autenticado = true;
  }

  logout() {
    this.autenticado = false;
  }
}