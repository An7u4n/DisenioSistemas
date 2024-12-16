import { AfterViewInit, Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgControl, FormControl,ValidationErrors, ValidatorFn, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ReservaService } from '../../../services/reserva.service';

@Component({
  selector: 'app-tipo-duracion',
  templateUrl: './tipo-duracion.component.html',
  styleUrl: './tipo-duracion.component.css'
})
export class TipoDuracionComponent implements OnInit, AfterViewInit{


  dias: string[] = [];
  activo: boolean = false;
  fechaClase: any;
  multiploDe30ErrorDesde: boolean = false;
  multiploDe30ErrorHasta: boolean = false;

  formulariosCard: FormGroup[] = [];


  constructor(private fb: FormBuilder, private renderer: Renderer2, private router: Router, private _reservaService: ReservaService) {

  }

  @ViewChild('calendario', { static: false }) calendarElement!: ElementRef;

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.renderizarCalendario();
    }, 10);
  }

  renderizarCalendario(){
    const calendarNativeElement = this.calendarElement.nativeElement;
    const shadowRoot = calendarNativeElement.shadowRoot;
    if (shadowRoot) {
      const headingPart = shadowRoot.querySelector('[part="heading"]');
      const divChild = headingPart.querySelector('div');

      this.renderer.setStyle(divChild, 'position', 'relative');
      this.renderer.setStyle(divChild, 'left', '-178px');
    }
    calendarNativeElement.isDateDisallowed(new Date());
  }

  desactivarFechas(fecha: Date): boolean {
    if(fecha < new Date()) {
      return true;
    } else if(fecha.getDay() == 5 || fecha.getDay() == 6) return true;
    else return false
  }
  
  submitTipoReserva(event: Event, calendario: any) {
    /*
    this.multiploDe30ErrorDesde = !this.esMultiploDe30(this.datosReserva.value.comienzoReserva);
    this.multiploDe30ErrorHasta = !this.esMultiploDe30(this.datosReserva.value.finReserva);
    if(!this.multiploDe30ErrorDesde && !this.multiploDe30ErrorHasta && this.datosReserva.value.comienzoReserva < this.datosReserva.value.finReserva) {
        this.datosReserva.value.fechaClase = calendario.value;
        console.log(this.datosReserva.value);
        this._reservaService.setReserva(this.datosReserva.value);
        this.router.navigate(['/registrar-reserva/esporadica/datos-reserva']);
    }*/
        let reservasValidas = true; 
        this.formulariosCard.forEach((formGroup, index) => {
          const comienzoReserva = formGroup.get('comienzoReserva')?.value;
          const finReserva = formGroup.get('finReserva')?.value;
      
          const esMultiploDe30Desde = this.esMultiploDe30(comienzoReserva);
          const esMultiploDe30Hasta = this.esMultiploDe30(finReserva);
      
          if (!esMultiploDe30Desde) {
            this.multiploDe30ErrorDesde = true;
            reservasValidas = false;
          } else {
            this.multiploDe30ErrorDesde = false;
          }
      
          if (!esMultiploDe30Hasta) {
            this.multiploDe30ErrorHasta = true;
            reservasValidas = false;
          } else {
            this.multiploDe30ErrorHasta = false;
          }
      
          if (comienzoReserva >= finReserva) {
            reservasValidas = false;
          }
        });
      
        if (reservasValidas) {

          const reservas = this.formulariosCard.map(formGroup => {
            return {
              dia: formGroup.get('dia')?.value,
              comienzoReserva: formGroup.get('comienzoReserva')?.value,
              finReserva: formGroup.get('finReserva')?.value
            };
          });
          var dias: { fecha: any; horaInicio: any; duracionMinutos: any; }[] = [];
          reservas.forEach((reserva, index) => {
            dias.push(
              {
                "fecha": this.dias[index],
                "horaInicio": reserva.comienzoReserva,
                "duracionMinutos": this.minutosEntreDosHoras(reserva.comienzoReserva, reserva.finReserva)
              });
          });      
          console.log("Dias:", dias);
          this._reservaService.setDiasEsporadica(dias);  // Llamar al servicio para guardar los dias
          this.router.navigate(['/registrar-reserva/esporadica/datos-reserva']);
        }
  }

  minutosEntreDosHoras(horaInicio: string, horaFin: string): number {
    const horaInicioArray = horaInicio.split(':');
    const horaFinArray = horaFin.split(':');

    const minutosInicio = parseInt(horaInicioArray[0]) * 60 + parseInt(horaInicioArray[1]);
    const minutosFin = parseInt(horaFinArray[0]) * 60 + parseInt(horaFinArray[1]);

    return minutosFin - minutosInicio;
  }

  esMultiploDe30(time: string): boolean {
    const [hour, minute] = time.split(':').map(Number);
    const totalMinutes = hour * 60 + minute;
    return totalMinutes % 30 === 0;
  }

  volver() {
    this.router.navigate(['/registrar-reserva']);
  }

  volverHome() {
    this.router.navigate(['/home']);
  }

  seleccionarDia(calendario: any) {
    this.dias = calendario.value.split(' ');
    this.formulariosCard = [];
    this.dias.forEach(dia => {
      const formGroup = new FormGroup({
        'comienzoReserva': new FormControl('', [Validators.required]),
        'finReserva': new FormControl('', [Validators.required]),
      },[this.validarHora]);
      
    
      this.formulariosCard.push(formGroup);
    });
  }

  validarHora(control: AbstractControl): ValidationErrors | null {
    const formGroup = control as FormGroup; // Convertir a FormGroup explícitamente
    const comienzoReserva = formGroup.get('comienzoReserva')?.value;
    const finReserva = formGroup.get('finReserva')?.value;
  
    // Verifica si la hora de inicio es mayor que la hora de fin
    if (comienzoReserva && finReserva && comienzoReserva >= finReserva) {
      return { 'comienzoMayorQueFin': true };
    }
    return null;
  }


  checkTodosValidos(): boolean {
    return this.formulariosCard.every(formGroup => formGroup.valid) && this.dias.length != 0;
  }

}
