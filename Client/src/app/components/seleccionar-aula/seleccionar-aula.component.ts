
import { Component, Input, OnInit } from '@angular/core';
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

  seleccionPorDia: { [dia: string]: any } = {};
  
  mapaAulasPorDia : Map<number,any> = new Map();

  constructor(private aulaService: AulaService, private router: Router, private reservaService : ReservaService, private toastr:ToastrService) { }
  
  ngOnInit(){
    this.aulasData = this.aulaService.getAulas().data;
    /*
    this.dias = aulasData
      .filter((a: any) => typeof a.diaSemana === 'number' && a.diaSemana >= 0 && a.diaSemana <= 6)
      .map((a: any) => this.DiasSemana[a.diaSemana]);
      console.log(this.aulas);

    aulasData.forEach((element: { diaSemana: number; aulasDisponibles: any; }) => {
      this.mapaAulasPorDia.set(element.diaSemana, element.aulasDisponibles)
    }
    );
    this.obtenerTresMejoresAulas();*/
  }

  cancelar() {
    this.router.navigate(['/home']);
  }
  volver() {
    throw new Error('Method not implemented.');
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
