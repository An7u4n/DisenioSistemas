
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
  dias = ['Lunes','Martes','Miercoles']
  
  constructor(private aulaService: AulaService, private router: Router) { }
  
  ngOnInit(){
    var aulas = this.aulaService.getAulas().data;
    console.log("LOL LAS AULAS ", aulas);
    this.aulas = aulas;
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
