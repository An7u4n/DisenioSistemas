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
      horaInicio: new FormControl({ value: '', disabled: true }),
      horaFin: new FormControl({ value: '', disabled: true })
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

  get diasFormArray(): FormArray {
    return this.tipoReservaForm.get('dias') as FormArray;
  }

  goBack() {
    this.router.navigate(['/registrar-reserva']);
  }

  next() {
    const diasSeleccionados = this.diasFormArray.value
      .map((dia: any, index: number) => ({
        dia: this.days[index],
        habilitado: dia.habilitado,
        horaInicio: dia.horaInicio,
        horaFin: dia.horaFin
      }))
      .filter((dia: any) => dia.habilitado);

    this._reservaService.setReserva(diasSeleccionados);
    this.router.navigate(['/registrar-reserva/periodica/datos-reserva']);
  }

  cancel() {
    this.router.navigate(['/home']);
  }
}
