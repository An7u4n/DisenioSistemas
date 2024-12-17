import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private autenticado: boolean = false;
  private isAdmin : boolean = false;


  private authUrl = 'https://localhost:7030/api/Auth';

  constructor(private http:HttpClient){
  }

  estaAutenticado(): boolean {
    return this.autenticado;
  }

  login(loginDTO: any): Observable<any> {
    return this.http.post<any>(this.authUrl, loginDTO).pipe(
      catchError((error) => {
        return throwError(() => new Error('Error en la solicitud de autenticación'));
      })
    );
  }

  procesarLoginResponse(response: any): void {
    if (response.success) {
      this.autenticado = true;
      this.isAdmin = response.data.isAdmin;
      console.log('Usuario autenticado:', response.data.name);
    } else {
      if (response.message === 'La contraseña es incorrecta') {
        console.log('Error: Contraseña incorrecta');
      } else if (response.message === 'No existe el usuario') {
        console.log('Error: Usuario no encontrado');
      }
      throw new Error(response.message);
    }
  }
}