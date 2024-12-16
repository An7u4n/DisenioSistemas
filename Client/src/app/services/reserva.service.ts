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

  setDiasPeriodica(dias: any) {
    dias.forEach((dia: any) => {
      dia = {
        diaSemana: dia.diaSemana,
        horaInicio: dia.horaInicio,
        duracionMinutos: this.minutosEntreDosHoras(dia.horaInicio, dia.horaFin)
      }
    }
    );
    this.diasPeriodica = dias;
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

  obtenerAulas(reserva: any){
    console.log(reserva);
    if(this.diasEsporadica != undefined)
      return this._http.post(this.urlReserva+'/retornar-aulas-esporadica', reserva);
    else if(this.diasPeriodica != undefined)
      return this._http.post(this.urlReserva+'/retornar-aulas-periodica', reserva);
    else throw new Error("No se setearon dias");
  }

  postReservaEsporadica(reserva: any){
    return this._http.post(this.urlReserva+'/guardar-reserva-esporadica', reserva);
  }

  minutosEntreDosHoras(horaInicio: string, horaFin: string): number {
    const horaInicioArray = horaInicio.split(':');
    const horaFinArray = horaFin.split(':');
  
    const minutosInicio = parseInt(horaInicioArray[0]) * 60 + parseInt(horaInicioArray[1]);
    const minutosFin = parseInt(horaFinArray[0]) * 60 + parseInt(horaFinArray[1]);
  
    return minutosFin - minutosInicio;
  }
}
