import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-periodica',
  templateUrl: './periodica.component.html',
  styleUrl: './periodica.component.css'
})
export class PeriodicaComponent {
  tipoReservaForm!: FormGroup;
  days = ['Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes'];
  selectedDays: string[] = [];

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.tipoReservaForm = this.fb.group({
      tipoReserva: ['', Validators.required],
      duracion: ['', Validators.required],
      startTime: [''],
      endTime: ['']
    });
  }

  toggleDay(day: string) {
    if (this.selectedDays.includes(day)) {
      this.selectedDays = this.selectedDays.filter(d => d !== day);
    } else {
      this.selectedDays.push(day);
    }
  }

  goBack() {
    console.log('Volver');
  }

  next() {
    console.log('Siguiente');
  }

  cancel() {
    console.log('Cancelar');
  }
}
