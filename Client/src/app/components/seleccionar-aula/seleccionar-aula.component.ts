
import { Component, Input, OnInit } from '@angular/core';
import { AulaService } from '../../services/aula.service';
import { Router } from '@angular/router';
import { AulaDTO } from '../../model/dto/AulaDTO';

@Component({
  selector: 'app-seleccionar-aula',
  templateUrl: './seleccionar-aula.component.html',
  styleUrl: './seleccionar-aula.component.css'
})
export class SeleccionarAulaComponent implements OnInit {
  aulas: any[] = [];
  dias = [];
  DiasSemana: { [key: number]: string } = {
    0: 'Domingo',
    1: 'Lunes',
    2: 'Martes',
    3: 'Miércoles',
    4: 'Jueves',
    5: 'Viernes',
    6: 'Sábado'
  };
  
  constructor(private aulaService: AulaService, private router: Router) { }
  
  ngOnInit(){
    var aulas = this.aulaService.getAulas().data;
    console.log("LOL LAS AULAS ", aulas);
    this.aulas = aulas[0];
    this.dias = aulas
      .filter((a: any) => typeof a.diaSemana === 'number' && a.diaSemana >= 0 && a.diaSemana <= 6)
      .map((a: any) => this.DiasSemana[a.diaSemana]);
  }


  cancelar() {
    this.router.navigate(['/home']);
  }
  volver() {
  throw new Error('Method not implemented.');
  }
  registrarReserva() {
  throw new Error('Method not implemented.');
  }
}
