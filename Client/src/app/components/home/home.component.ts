import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  constructor(private router: Router, private loginservice: LoginService) { }
  indiceOpcionSeleccionada: number = 3;

  isAdmin: boolean = false;

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if(!this.isAdmin){
      if (event.key === 'ArrowLeft') {
        this.indiceOpcionSeleccionada = 2
      } else if (event.key === 'ArrowRight') {
        this.indiceOpcionSeleccionada = 2
      } else if (event.key === 'Enter') this.redirigir();
    } else{
      if (event.key === 'ArrowLeft') {
        this.indiceOpcionSeleccionada = Math.max(this.indiceOpcionSeleccionada - 1, 0);
      } else if (event.key === 'ArrowRight') {
        this.indiceOpcionSeleccionada = Math.min(this.indiceOpcionSeleccionada + 1, 1);
      } else if (event.key === 'Enter') this.redirigir();
    }
  }

  ngOnInit(): void {
    this.isAdmin = this.loginservice.isAdmin();
  }
  
  hoverCircle(number: number) {
    this.indiceOpcionSeleccionada = number;
  }

  redirigir() {
    if (this.indiceOpcionSeleccionada === 0) {
      this.router.navigate(['/registrar-bedel']);
    } else if(this.indiceOpcionSeleccionada === 1) {
      this.router.navigate(['/buscar-bedel']);
    } else if (this.indiceOpcionSeleccionada === 2) {
      this.router.navigate(['/registrar-reserva']);
    }
  }

  isSelected(index: number): boolean {
    return this.indiceOpcionSeleccionada === index;
  }
}
