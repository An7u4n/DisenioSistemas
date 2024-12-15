
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-seleccionar-aula',
  templateUrl: './seleccionar-aula.component.html',
  styleUrl: './seleccionar-aula.component.css'
})
export class SeleccionarAulaComponent {
cancelar() {
throw new Error('Method not implemented.');
}
volver() {
throw new Error('Method not implemented.');
}
registrarReserva() {
throw new Error('Method not implemented.');
}

aulas = [
  { id: 1, ubicacion: 'Edificio A, Piso 1', capacidad: 30 },
  { id: 2, ubicacion: 'Edificio B, Piso 2', capacidad: 25 },
  { id: 3, ubicacion: 'Edificio C, Piso 3', capacidad: 40 },
  { id: 4, ubicacion: 'Edificio D, Piso 1', capacidad: 20 }
];

  //@Input() aulas = [];

  dias = ['Lunes','Martes','Miercoles']

}
