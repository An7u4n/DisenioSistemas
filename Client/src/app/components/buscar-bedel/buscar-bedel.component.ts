import { Component } from '@angular/core';
import { BedelService } from '../../services/bedel.service';
import { BedelDTO } from '../../model/dto/BedelDTO';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buscar-bedel',
  templateUrl: './buscar-bedel.component.html',
  styleUrl: './buscar-bedel.component.css'
})
export class BuscarBedelComponent {
  mostrarFormulario = true;
  mostrarBedeles = false;
  mostrarError = false;
  bedeles: BedelDTO[] = [];

  bedelData = {
    apellido: '',
    turno: 0
  };
  constructor(private bedelService: BedelService, private router: Router) { }

  buscarBedeles(e: Event) {
    e.preventDefault();
    this.bedelService.buscarBedel(this.bedelData.apellido, this.bedelData.turno).subscribe( res => {
      this.bedeles = res.data;
      this.mostrarTablaBedeles();
    }, error => {
      if(error.status === 404) {
        this.mostrarError = true;
        this.mostrarBedeles = false;
        this.mostrarFormulario = false;
      }
    });
  }

  mostrarTablaBedeles() {
    this.mostrarFormulario = false;
    this.mostrarError = false;
    this.mostrarBedeles = true;
  }

  onVolver() {
    this.mostrarFormulario = true;
    this.mostrarError = false;
    this.mostrarBedeles = false;
  }

  onVolverHome() {
    this.router.navigate(['/home']);
  }
}
