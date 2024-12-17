import { Component, Input, Renderer2 } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ReservaService } from '../../../services/reserva.service';
import { config } from 'rxjs';
import { AulaService } from '../../../services/aula.service';

@Component({
  selector: 'app-datos-reserva',
  templateUrl: './datos-reserva.component.html',
  styleUrl: './datos-reserva.component.css'
})
export class DatosReservaComponent {
  fechaClase: any;
  datosComision!: FormGroup;
  datosReserva!: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private reservaService: ReservaService, private aulaService: AulaService) { }

  ngOnInit() {
    this.datosReserva = this.fb.group({
      tipoReserva: ['esporadica', [Validators.required]],
      comienzoReserva: ['', [Validators.required]],
      finReserva: ['', [Validators.required]]
    });

    this.datosComision = this.fb.group({
      tipoAula: ['', [Validators.required]],
      cantidadAlumnos: ['', [Validators.required]],
      nombre: ['', [Validators.required]],
      apellido: ['', [Validators.required]],
      catedra: ['', [Validators.required]],
      comision: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  submitDatosComision() {
    let datos = this.datosComision.value;
  

    var reserva = {
      profesor: datos.nombre + ' ' + datos.apellido,
      nombreCatedra: datos.catedra + ' ' + datos.comision,
      correoElectronico: datos.email,
      cantidadAlumnos: datos.cantidadAlumnos,
      idBedel: 1, // Hardcoded, TODO: cambiar por el id del bedel logueado
      idCuatrimestre: 1, // Hardcoded, TODO: cambiar por el id del cuatrimestre actual
      tipoAula: Number(datos.tipoAula),
      dias: this.reservaService.getDias(),
    };
    this.reservaService.setReserva(reserva);
    this.reservaService.obtenerAulas(reserva).subscribe(res => {
      console.log(res);
      this.aulaService.setAulas(res);
      this.reservaService.navegarAulas();
    });
  }

  minutosEntreDosHoras(horaInicio: string, horaFin: string): number {
    const horaInicioArray = horaInicio.split(':');
    const horaFinArray = horaFin.split(':');

    const minutosInicio = parseInt(horaInicioArray[0]) * 60 + parseInt(horaInicioArray[1]);
    const minutosFin = parseInt(horaFinArray[0]) * 60 + parseInt(horaFinArray[1]);

    return minutosFin - minutosInicio;
  }

  volverHome() {
    this.router.navigate(['/home']);
  }

  volverReserva() {
    this.router.navigate(['/registrar-reserva']);
  }

  cancelar(){
    this.router.navigate(['/home']);
  }
}
