
import { Component, HostListener, Input, OnInit } from '@angular/core';
import { AulaService } from '../../services/aula.service';
import { Router } from '@angular/router';
import { AulaDTO } from '../../model/dto/AulaDTO';
import { ReservaService } from '../../services/reserva.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-seleccionar-aula',
  templateUrl: './seleccionar-aula.component.html',
  styleUrl: './seleccionar-aula.component.css'
})
export class SeleccionarAulaComponent implements OnInit {

  aulasData: any[] = [];

  dias = [];
  DiasSemana: { [key: number]: string } = {
    0: 'Domingo',
    1: 'Lunes',
    2: 'Martes',
    3: 'Miércoles',
    4: 'Jueves',
    5: 'Viernes',
    6: 'Sábado'
  };

  @HostListener('window:keydown', ['$event'])
    handleKeyDown(event: KeyboardEvent) {
      if(event.key === 'Enter') {
        this.registrarReserva();
      }
  }

  seleccionPorDia: { [dia: string]: any } = {};
  
  mapaAulasPorDia : Map<number,any> = new Map();

  constructor(private aulaService: AulaService, private router: Router, private reservaService : ReservaService, private toastr:ToastrService) { }
  
  ngOnInit(){
    this.aulasData = this.aulaService.getAulas().data;
  }

  obtenerTipoPizarron(aula: any) {
    console.log(aula);
    let detalleRetorno = '';
    if (aula.tipoDePizarron == 1) detalleRetorno += 'Pizarron de Tiza'
    else if (aula.tipoDePizarron == 2) detalleRetorno += 'Pizarron de Fibron'
    else detalleRetorno += 'Pizzarron de Tiza Y Fibron';

    if (aula.aireAcondicionado == true) detalleRetorno += ', posee aire acondicionado'

    return detalleRetorno
  }

  cancelar() {
    this.reservaService.limpiarService();
    this.router.navigate(['/home']);
  }

  registrarReserva() {
    var reservaActual = this.reservaService.getReserva();


    console.log(reservaActual);
    console.log(this.seleccionPorDia);

    var diasNuevo: any[] = [];
    reservaActual.dias.forEach((element: { fecha: any; horaInicio: any; duracionMinutos: any;}) => {
      console.log(element);
      diasNuevo.push({
        "numeroAula": this.seleccionPorDia[element.fecha+"T00:00:00"].numero,
        "fecha": element.fecha,
        "horaInicio": element.horaInicio,
        "duracionMinutos": element.duracionMinutos
      });
    });
    reservaActual.dias = diasNuevo;
    console.log(reservaActual);
    this.reservaService.postReservaEsporadica(reservaActual).subscribe(() =>{
        this.toastr.success("Reserva cargada exitosamente")
        this.router.navigate(['/home']);
      },
      error => {
        this.toastr.error("Error al cargar la reserva");
        throw new Error(error)
      }
    );
  }
}
