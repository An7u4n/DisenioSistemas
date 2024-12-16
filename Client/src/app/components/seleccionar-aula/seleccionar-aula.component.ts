
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
  selectedAulas: { [key: number]: any } = {};

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
  
  mapaAulasPorDia : Map<number,any> = new Map();

  constructor(private aulaService: AulaService, private router: Router) { }
  
  ngOnInit(){
    var aulasData = this.aulaService.getAulas().data;
    console.log("LOL LAS AULAS ", aulasData);
    this.dias = aulasData
      .filter((a: any) => typeof a.diaSemana === 'number' && a.diaSemana >= 0 && a.diaSemana <= 6)
      .map((a: any) => this.DiasSemana[a.diaSemana]);
      console.log(this.aulas);

    aulasData.forEach((element: { diaSemana: number; aulasDisponibles: any; }) => {
      this.mapaAulasPorDia.set(element.diaSemana, element.aulasDisponibles)
    }
    );
    this.obtenerTresMejoresAulas();
  }

  obtenerTresMejoresAulas(){
    var aulas= new Set()
    this.mapaAulasPorDia.forEach(k => {
      k.forEach((aula: any) => aulas.add(aula));
    })
    this.aulas= [...aulas].sort((a:any,b:any) => a.capacidad - b.capacidad);
    this.aulas.splice(3);
  }


  aulaNoPertenece(aula: any,dia: number): boolean {
    const aulas = this.mapaAulasPorDia.get(dia);
    return aulas ? aulas.includes(aula) : false;
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

  seleccionarAula(aula: any, diaIndex: number): void {
    console.log("LOOOL",aula,diaIndex);
    this.selectedAulas[diaIndex] = aula;
  }
}
