import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  private urlReserva = 'https://localhost:7030/api/Reserva';
  constructor(private _http: HttpClient) {}
  private datosReserva: any;
  setReserva(reserva: any) {
    this.datosReserva = reserva;
  }

  getReserva() {
    return this.datosReserva;
  }

  postReserva(reserva: any){
    return this._http.post(this.urlReserva+'/guardar-reserva-esporadica', reserva);
  }
}
