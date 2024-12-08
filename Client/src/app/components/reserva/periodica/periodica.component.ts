import { Component } from '@angular/core';
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

  ngOnInit() {
    this.tipoReservaForm = this.fb.group({
      tipoReserva: ['Periódica', Validators.required],
      duracion: ['', Validators.required],
      dias: this.fb.array(this.days.map(() => this.crearDiaFormGroup()))
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

  esMultiploDe30(time: string): boolean {
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
    const diasSeleccionados = this.diasFormArray.value
    .map((dia: any, index: number) => ({
      dia: this.days[index],
      habilitado: dia.habilitado,
      horaInicio: dia.horaInicio,
      horaFin: dia.horaFin
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
    this._reservaService.setReserva(diasSeleccionados);
    this.router.navigate(['/registrar-reserva/periodica/datos-reserva']);
  }

  cancel() {
    this.router.navigate(['/home']);
  }
}
