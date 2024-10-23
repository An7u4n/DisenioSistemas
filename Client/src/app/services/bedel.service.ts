import { Injectable } from '@angular/core';
import { BedelDTO } from '../model/dto/BedelDTO';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiResponse } from '../model/api-response.model';

@Injectable({
  providedIn: 'root'
})
export class BedelService {
  private userUrl = 'https://localhost:7030/api/User';
  constructor(private _http: HttpClient) { }


  registrarBedel(bedel: BedelDTO) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this._http.post<ApiResponse>(`${this.userUrl}/registrar-bedel`, JSON.stringify(bedel), { headers });
  }
}
