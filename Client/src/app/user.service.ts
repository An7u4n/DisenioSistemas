import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BedelDTO } from './model/dto/BedelDTO';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = "https://localhost:7030/api/User";

  constructor(private http: HttpClient) { }

  registrarBedel(data: BedelDTO): Observable<Response> {
    return this.http.post<Response>(`${this.apiUrl}/registrar-bedel`, data);
  }
}
