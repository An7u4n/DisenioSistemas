import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  constructor(private router: Router) { }
  indiceOpcionSeleccionada: number = 0;

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'ArrowLeft') {
      this.indiceOpcionSeleccionada = Math.max(this.indiceOpcionSeleccionada - 1, 0);
    } else if (event.key === 'ArrowRight') {
      this.indiceOpcionSeleccionada = Math.min(this.indiceOpcionSeleccionada + 1, 2);
    } else if (event.key === 'Enter'){
      if (this.indiceOpcionSeleccionada === 0) {
        this.router.navigate(['/registrar-bedel']);
      } else if (this.indiceOpcionSeleccionada === 2) {
        this.router.navigate(['/registrar-reserva']);
      }
    }
  }

  isSelected(index: number): boolean {
    return this.indiceOpcionSeleccionada === index;
  }
}
