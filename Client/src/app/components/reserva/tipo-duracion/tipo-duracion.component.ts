import { AfterViewInit, Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tipo-duracion',
  templateUrl: './tipo-duracion.component.html',
  styleUrl: './tipo-duracion.component.css'
})
export class TipoDuracionComponent implements OnInit, AfterViewInit{
  activo: boolean = false;
  formulario1: boolean = true;
  formulario2: boolean = false;
  fechaClase: any;
  datosReserva!: FormGroup;
  datosComision!: FormGroup;
  multiploDe30ErrorDesde: boolean = false;
  multiploDe30ErrorHasta: boolean = false;

  constructor(private fb: FormBuilder, private renderer: Renderer2, private router: Router) {

  }

  @ViewChild('calendario', { static: false }) calendarElement!: ElementRef;

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

  volverReserva() {
    this.formulario1 = !this.formulario1;
    this.formulario2 = !this.formulario2;
    setTimeout(() => {
      this.renderizarCalendario();
    }, 10);
  }

  desactivarFechas(fecha: Date): boolean {
    if(fecha < new Date()) {
      return true;
    } else if(fecha.getDay() == 5 || fecha.getDay() == 6) return true;
    else return false
  }
  
  submitTipoReserva(event: Event, calendario: any) {
    this.multiploDe30ErrorDesde = !this.esMultiploDe30(this.datosReserva.value.comienzoReserva);
    this.multiploDe30ErrorHasta = !this.esMultiploDe30(this.datosReserva.value.finReserva);
    if(!this.multiploDe30ErrorDesde && !this.multiploDe30ErrorHasta) {
        this.formulario1 = false;
        this.formulario2 = true;
        this.fechaClase = calendario.value;
    }
  }

  submitDatosComision() {
    const configCombinada = {
      ...this.datosReserva.value,
      ...this.datosComision.value,
      fechaClase: this.fechaClase
    };

    console.log(configCombinada);
  }

  chequearFormulario() {
    this.activo = !this.activo;
  }

  esMultiploDe30(time: string): boolean {
    const [hour, minute] = time.split(':').map(Number);
    const totalMinutes = hour * 60 + minute;
    return totalMinutes % 30 === 0;
  }

  volverHome() {
    this.router.navigate(['/home']);
  }

}
