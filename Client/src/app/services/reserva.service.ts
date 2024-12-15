import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  private urlReserva = 'http://localhost:7044/api/reserva';
  constructor(private _http: HttpClient) {}
  private datosReserva: any;
  setReserva(reserva: any) {
    this.datosReserva = reserva;
  }

  getReserva() {
    return this.datosReserva;
  }

  postReserva(){
    this._http.post(this.urlReserva+'/guardar-reserva-esporadica', this.datosReserva).subscribe((res) => {
      console.log(res);
    });
  }
}
