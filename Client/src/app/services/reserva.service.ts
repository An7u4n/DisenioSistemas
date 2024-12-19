import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  private urlReserva = 'https://localhost:7030/api/Reserva';
  constructor(private _http: HttpClient, private router: Router) {}
  private datosReserva: any;
  private diasEsporadica: any;
  private diasPeriodica: any;
  private anio: string = '';
  private datosSolapamiento: any;
  private datosPeriodo: any;

  guardarAnio(anio: number) {
    this.anio = anio.toString();
  }

  setDiasEsporadica(dias: any) {
    this.diasEsporadica = dias;
  }

  setDatosPeriodo(datos: any) {
    this.datosPeriodo = datos;
  }

  getDatosPeriodo() {
    return this.datosPeriodo;
  }

  setDiasPeriodica(dias: any) {
    var diasGuardar: any[] = [];
    dias.forEach((dia: any) => {
      console.log(dia);
      var diaAGuardar = {
        diaSemana: dia.diaSemana,
        horaInicio: dia.horaInicio,
        duracionMinutos: this.minutosEntreDosHoras(dia.horaInicio, dia.horaFin)
      }
      diasGuardar.push(diaAGuardar);
    }
    );
    this.diasPeriodica = diasGuardar;
  }

  setSolapamiento(solapamiento: any) {
    this.datosSolapamiento = solapamiento;
  }

  getSolapamiento(){
    return this.datosSolapamiento;
  }

  navegarAulas(){
    if(this.diasEsporadica != undefined)
      this.router.navigate(['registrar-reserva/esporadica/seleccionar-aula']); 
    else if(this.diasPeriodica != undefined)
      this.router.navigate(['registrar-reserva/periodica/seleccionar-aula']);
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
    if(this.diasEsporadica != undefined)
      return this._http.post(this.urlReserva+'/retornar-aulas-esporadica', reserva);
    else if(this.diasPeriodica != undefined){
      reserva.fechaInicio = this.anio+"-01-01";
      reserva.fechaFin = this.anio+'-12-31';
      return this._http.post(this.urlReserva+'/retornar-aulas-periodica', reserva);
    }
    else throw new Error("No se setearon dias");
  }

  postReservaEsporadica(reserva: any){
    return this._http.post(this.urlReserva+'/guardar-reserva-esporadica', reserva);
  }

  postReservaPeriodica(reserva: any){
    console.log(this.datosPeriodo);


    return this._http.post(this.urlReserva+'/guardar-reserva-periodica', reserva);
  }

  minutosEntreDosHoras(horaInicio: string, horaFin: string): number {
    if(horaInicio == undefined || horaFin == undefined) return 0;
    const horaInicioArray = horaInicio.split(':');
    const horaFinArray = horaFin.split(':');
  
    const minutosInicio = parseInt(horaInicioArray[0]) * 60 + parseInt(horaInicioArray[1]);
    const minutosFin = parseInt(horaFinArray[0]) * 60 + parseInt(horaFinArray[1]);
  
    return minutosFin - minutosInicio;
  }
}
