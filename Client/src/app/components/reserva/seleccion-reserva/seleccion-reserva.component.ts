import { Component, HostListener, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-seleccion-reserva',
  templateUrl: './seleccion-reserva.component.html',
  styleUrl: './seleccion-reserva.component.css'
})
export class SeleccionReservaComponent implements OnInit{
  tipoReserva!: FormGroup;
  constructor(private fb: FormBuilder, private router: Router) {}

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if(event.key === 'Enter') {
      this.submitTipoReserva();
    }
  }

  ngOnInit() {
    this.tipoReserva = this.fb.group({
      tipoReserva: ['esporadica', [Validators.required]],
    });
  }

  submitTipoReserva() {
    this.router.navigate(['/registrar-reserva/esporadica']);
    console.log('Tipo de reserva seleccionado');
  }
}
