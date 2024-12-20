import { Component, HostListener } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ReservaService } from '../../../services/reserva.service';

@Component({
  selector: 'app-periodica',
  templateUrl: './periodica.component.html',
  styleUrl: './periodica.component.css'
})
export class PeriodicaComponent {
  tipoReservaForm!: FormGroup;
  days = ['Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes'];
  errorHorarios = false;
  errorInicioMayor = false;

  constructor(private fb: FormBuilder, private router: Router, private _reservaService: ReservaService) {}

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if(event.key === 'Enter') {
      this.submitReserva(event);
    }
  }

  ngOnInit() {
    this.tipoReservaForm = this.fb.group({
      tipoReserva: ['Periódica', Validators.required],
      duracion: ['', Validators.required],
      anio: [2025, [Validators.required, Validators.min(2025)]],
      dias: this.fb.array(this.days.map(() => this.crearDiaFormGroup()))
    });

    this.tipoReservaForm.valueChanges.subscribe(() => {
      const diasSeleccionados = this.diasFormArray.controls.some((control) => control.get('habilitado')?.value);
      this.tipoReservaForm.controls['dias'].setErrors(diasSeleccionados ? null : { noDiasSeleccionados: true });
    });
  }

  crearDiaFormGroup(): FormGroup {
    return this.fb.group({
      habilitado: new FormControl(false),
      horaInicio: new FormControl({ value: '', disabled: true }, Validators.required),
      horaFin: new FormControl({ value: '', disabled: true }, Validators.required)
    });
  }

  toggleDia(index: number): void {
    const diaFormGroup = this.diasFormArray.at(index) as FormGroup;
    const habilitado = diaFormGroup.get('habilitado')?.value;

    if (habilitado) {
      diaFormGroup.get('horaInicio')?.enable();
      diaFormGroup.get('horaFin')?.enable();
      
    } else {
      diaFormGroup.get('horaInicio')?.disable();
      diaFormGroup.get('horaFin')?.disable();
    }
  }

  esMultiploDe30(time?: string): boolean {
    if(time == undefined) return true;
    const [hour, minute] = time.split(':').map(Number);
    const totalMinutes = hour * 60 + minute;
    return totalMinutes % 30 === 0;
  }

  get diasFormArray(): FormArray {
    return this.tipoReservaForm.get('dias') as FormArray;
  }






  goBack() {
    this.router.navigate(['/registrar-reserva']);
  }

  
  submitReserva(e: Event) {
    e.preventDefault();
    this._reservaService.guardarAnio(this.tipoReservaForm.value.anio);
    console.log(this.diasFormArray.value);
    const diasSeleccionados = this.diasFormArray.value
    .map((dia: any, index: number) => ({
      diaSemana: index + 1,
      habilitado: dia.habilitado,
      horaInicio: dia.horaInicio,
      horaFin: dia.horaFin,
    }))
    .filter((dia: any) => dia.habilitado);
    if(diasSeleccionados.map((dia: any) => dia.horaInicio).some((hora: string) => !this.esMultiploDe30(hora)) || diasSeleccionados.map((dia: any) => dia.horaFin).some((hora: string) => !this.esMultiploDe30(hora))) {
      this.errorHorarios = true;
      return;
    }
    if(diasSeleccionados.some((dia: any) => dia.horaInicio >= dia.horaFin)) {
      this.errorInicioMayor = true;
      return;
    }
    console.log(diasSeleccionados);
    this._reservaService.setDiasPeriodica(diasSeleccionados);
    this.setearPeriodoYCuatrimestre();
    this.router.navigate(['/registrar-reserva/periodica/datos-reserva']);
  }

  setearPeriodoYCuatrimestre() {
    var datosPeriodo;
    console.log(this.tipoReservaForm.value);
    if(this.tipoReservaForm.value.duracion == '3'){
      datosPeriodo = {
        fechaInicio: this.tipoReservaForm.value.anio+'-03-01',
        fechaFin: this.tipoReservaForm.value.anio+'-11-30',
        tipoPeriodo: 1,
        numeroCuatrimestre: 0
      };
    } else if(this.tipoReservaForm.value.duracion == '1'){
      datosPeriodo = {
        fechaInicio: this.tipoReservaForm.value.anio+'-03-01',
        fechaFin: this.tipoReservaForm.value.anio+'-06-30',
        tipoPeriodo: 2,
        numeroCuatrimestre: 1
      };
    } else if(this.tipoReservaForm.value.duracion == '2'){
      datosPeriodo = {
        fechaInicio: this.tipoReservaForm.value.anio+'-07-01',
        fechaFin: this.tipoReservaForm.value.anio+'-11-30',
        tipoPeriodo: 2,
        numeroCuatrimestre: 2
      };
    }
    console.log(datosPeriodo);
    this._reservaService.setDatosPeriodo(datosPeriodo);
  }


  minutosEntreDosHoras(horaInicio?: string, horaFin?: string): number {
    if(horaInicio == undefined || horaFin == undefined || horaInicio == '' || horaFin == '' || horaInicio == null || horaFin == null) return 0;
    else{
      const horaInicioArray = horaInicio.split(':');
      const horaFinArray = horaFin.split(':');
  
      const minutosInicio = parseInt(horaInicioArray[0]) * 60 + parseInt(horaInicioArray[1]);
      const minutosFin = parseInt(horaFinArray[0]) * 60 + parseInt(horaFinArray[1]);
  
      return minutosFin - minutosInicio;
    }
  }
  
  cancel() {
    this.router.navigate(['/home']);
  }

  cambiarTipoReserva(){
    this.router.navigate(["registrar-reserva/esporadica"]);
  }

}
