import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  private datosReserva: any;
  setReserva(reserva: any) {
    this.datosReserva = reserva;
  }
  getReserva() {
    return this.datosReserva;
  }
}
