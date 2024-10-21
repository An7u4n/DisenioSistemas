import { Component } from '@angular/core';
import { UserService } from '../../user.service';
import { BedelDTO } from '../../model/dto/BedelDTO';

@Component({
  selector: 'app-registrar-bedel',
  templateUrl: './registrar-bedel.component.html',
  styleUrl: './registrar-bedel.component.css'
})
export class RegistrarBedelComponent {
  usuarioExistente: boolean = false;
  contraseniaIncorrecta: boolean = false;
  confirmarContrasenia: boolean = false;

  bedelData = {
    id: null, 
    nombre: '',
    apellido: '',
    turno: '',
    usuario: '',
    contrasenia: '',
    confirmarContrasenia: ''
  };

  constructor(private userService: UserService) { }

  registrarBedelSubmit(event: Event) {
    event.preventDefault();

    if (this.bedelData.contrasenia !== this.bedelData.confirmarContrasenia) {
      this.confirmarContrasenia = true;
      return;
    }
    const bedelDTO: BedelDTO = {
      idBedel: 0,  // Asignar null para que se genere en el backend
      nombre: this.bedelData.nombre,
      apellido: this.bedelData.apellido,
      turno: this.mapearTurno(this.bedelData.turno),
      usuario: this.bedelData.usuario
    };


    console.log(this.bedelData.turno);
    this.userService.registrarBedel(bedelDTO).subscribe(
      response => {
        console.log('Bedel registrado con éxito', response);
      },
      error => {
        console.error('Error al registrar el bedel', error);
      }
    );
  }

  cancelarRegistro() {
    
  }

  private mapearTurno(turno: string): number {
    switch (turno) {
      case "maniana":
        return 1;
      case "tarde":
        return 2;
      case "noche":
        return 3;
      default:
        return 0; // O un valor predeterminado si no coincide
    }
  }
}
