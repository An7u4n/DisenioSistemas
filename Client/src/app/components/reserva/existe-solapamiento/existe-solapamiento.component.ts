import { Component, OnInit } from '@angular/core';
import { ReservaService } from '../../../services/reserva.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-existe-solapamiento',
  templateUrl: './existe-solapamiento.component.html',
  styleUrl: './existe-solapamiento.component.css'
})
export class ExisteSolapamientoComponent implements OnInit {
  solapamientoData: any;
  constructor(private reservaService: ReservaService, private router: Router) { }
  
  ngOnInit(): void {
    this.solapamientoData = this.reservaService.getSolapamiento();
    console.log(this.solapamientoData);
  }

  obtenerHora(hora: number): string {
    const hours = Math.floor(hora);
    const minutes = Math.round((hora - hours) * 60);
    const formattedHours = hours.toString().padStart(2, '0');
    const formattedMinutes = minutes.toString().padStart(2, '0');
    return `${formattedHours}:${formattedMinutes} hs`;
  }

  volver(){
    this.router.navigate(['home']);
  }

}
