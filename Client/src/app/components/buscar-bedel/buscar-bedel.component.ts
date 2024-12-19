import { Component, HostListener } from '@angular/core';
import { BedelService } from '../../services/bedel.service';
import { BedelDTO } from '../../model/dto/BedelDTO';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

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
  bedelAActualizar!: BedelDTO;
  mostrarEdicion: boolean = false;

  bedelData = {
    apellido: '',
    turno: 0
  };
  constructor(private bedelService: BedelService, private router: Router, private toastr: ToastrService) { }

  @HostListener('window:keydown', ['$event'])
    handleKeyDown(event: KeyboardEvent) {
      if(event.key === 'Enter') {
        this.buscarBedeles(event);
      } else if(event.key === 'Escape') {
        this.onVolverHome();
      }
  }

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

  onCerrarModificarBedel(e: boolean) {
    this.mostrarEdicion = e;
  }

  onVolverHome() {
    this.router.navigate(['/home']);
  }

  editarBedel(bedel: any) {
    this.bedelAActualizar = bedel;
    this.mostrarEdicion = true;
  }

  onEliminarBedel(usuario: string | undefined) {
    this.bedelService.eliminarBedel(usuario).subscribe(res => {
      if (res.success) {
        this.toastr.success('El bedel fue eliminado', 'Elminacion Exitosa', {
        timeOut: 2000,
        closeButton: true,
        progressBar: true,
      });
      this.bedeles = this.bedeles.filter(bedel => bedel.usuario !== usuario);
    }
  });
  }
}
