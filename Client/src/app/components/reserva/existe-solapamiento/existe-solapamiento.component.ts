import { Component, OnInit } from '@angular/core';
import { ReservaService } from '../../../services/reserva.service';

@Component({
  selector: 'app-existe-solapamiento',
  templateUrl: './existe-solapamiento.component.html',
  styleUrl: './existe-solapamiento.component.css'
})
export class ExisteSolapamientoComponent implements OnInit {
  constructor(private reservaService: ReservaService) { }

  ngOnInit(): void {
    console.log(this.reservaService.getSolapamiento());
  }
}
