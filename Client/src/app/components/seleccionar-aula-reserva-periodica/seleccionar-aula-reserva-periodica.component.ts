import { Component, HostListener } from '@angular/core';
import { AulaService } from '../../services/aula.service';
import { Router } from '@angular/router';
import { ReservaService } from '../../services/reserva.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-seleccionar-aula-reserva-periodica',
  templateUrl: './seleccionar-aula-reserva-periodica.component.html',
  styleUrl: './seleccionar-aula-reserva-periodica.component.css'
})
export class SeleccionarAulaReservaPeriodicaComponent {
  diasConAulas: any[] = [];
  selectedAulas: { [key: number]: any } = {};

  seleccionPorDia: { [diaSemana: string]: any } = {};

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
  
  mapaAulasPorDia : Map<number,any> = new Map();

  @HostListener('window:keydown', ['$event'])
    handleKeyDown(event: KeyboardEvent) {
      if(event.key === 'Enter') {
        this.registrarReserva();
      }
  }

  constructor(private aulaService: AulaService, private router: Router, private reservaService: ReservaService, private toastr: ToastrService) { }
  
  ngOnInit(){
    this.diasConAulas = this.aulaService.getAulas().data;
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

  aulaNoPertenece(aula: any,dia: number): boolean {
    const aulas = this.mapaAulasPorDia.get(dia);
    return aulas ? aulas.includes(aula) : false;
  }

  cancelar() {
    this.reservaService.limpiarService();
    this.router.navigate(['/home']);
  }

  registrarReserva() {
    var reservaActual = this.reservaService.getReserva();

    var diasNuevo: any[] = [];

    reservaActual.dias.forEach((element: { diaSemana: string; horaInicio: any; duracionMinutos: any;}) => {
      console.log(element);
      console.log(this.seleccionPorDia);
      diasNuevo.push({
        "numeroAula": this.seleccionPorDia[element.diaSemana].numero,
        "diaSemana": element.diaSemana,
        "horaInicio": element.horaInicio,
        "duracionMinutos": element.duracionMinutos
      });
    });

    let datosCuatrimestre = this.reservaService.getDatosPeriodo();
    reservaActual.dias = diasNuevo;
    reservaActual.fechaInicio = datosCuatrimestre.fechaInicio;
    reservaActual.fechaFin = datosCuatrimestre.fechaFin;
    reservaActual.tipoPeriodo = datosCuatrimestre.tipoPeriodo;
    reservaActual.numeroCuatrimestre = datosCuatrimestre.numeroCuatrimestre;
    this.reservaService.postReservaPeriodica(reservaActual).subscribe(() =>{
        this.toastr.success("Reserva cargada exitosamente")
        this.router.navigate(['/home']);
      },
      error => {
        this.toastr.error("Error al cargar la reserva");
        throw new Error(error)
      }
    );
  }

  seleccionarAula(aula: any, diaIndex: number): void {
    this.selectedAulas[diaIndex] = aula;
  }

  eliminarAulasDuplicadas(aulas: any[]): any[] {
    const mapaAulas = new Map<number, any>();
  
    aulas.forEach(aula => {
      if (!mapaAulas.has(aula.numero)) {
        mapaAulas.set(aula.numero, aula);
      }
    });
  
    return Array.from(mapaAulas.values());
  }
}
