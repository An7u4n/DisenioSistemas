import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  private urlReserva = 'https://localhost:7030/api/Reserva';
  constructor(private _http: HttpClient) {}
  private datosReserva: any;
  private diasEsporadica: any;
  private diasPeriodica: any;
  setDiasEsporadica(dias: any) {
    this.diasEsporadica = dias;
  }

  getDias() {
    if(this.diasEsporadica != undefined)
      return this.diasEsporadica;
    else if(this.diasPeriodica != undefined)
      return this.diasPeriodica;
    else throw new Error("No se setearon dias");
  }

  setReserva(reserva: any) {
    this.datosReserva = reserva;
  }

  getReserva() {
    return this.datosReserva;
  }

  obtenerAulasEsporadica(reserva: any){
    return this._http.post(this.urlReserva+'/retornar-aulas-esporadica', reserva);
  }

  postReservaEsporadica(reserva: any){
    return this._http.post(this.urlReserva+'/guardar-reserva-esporadica', reserva);
  }
}
