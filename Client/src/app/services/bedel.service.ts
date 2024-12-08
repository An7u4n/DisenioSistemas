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

  buscarBedel(apellido?: string, turno?: number) {
    if(apellido && turno) {
      return this._http.get<ApiResponse>(`${this.userUrl}/buscar-bedeles?apellido=${apellido}&turno=${turno}`);
    } else if(apellido) {
      return this._http.get<ApiResponse>(`${this.userUrl}/buscar-bedeles?apellido=${apellido}`);
    } else if(turno) {
      return this._http.get<ApiResponse>(`${this.userUrl}/buscar-bedeles?turno=${turno}`);
    } else {
      return this._http.get<ApiResponse>(`${this.userUrl}/buscar-bedeles`);
    }
  }

  eliminarBedel(usuario: string | undefined) {
    return this._http.delete<ApiResponse>(`${this.userUrl}/eliminar-bedel?usuario=${usuario}`)
  }

  actualizarBedel(bedel: BedelDTO) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this._http.put<ApiResponse>(`${this.userUrl}/modificar-bedel`, JSON.stringify(bedel), { headers });
  }
}
