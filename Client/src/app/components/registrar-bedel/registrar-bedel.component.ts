import { Component } from '@angular/core';
import { BedelDTO } from '../../model/dto/BedelDTO';
import { BedelService } from '../../services/bedel.service';

@Component({
  selector: 'app-registrar-bedel',
  templateUrl: './registrar-bedel.component.html',
  styleUrl: './registrar-bedel.component.css'
})
export class RegistrarBedelComponent {
  usuarioExistente: boolean = false;
  contraseniaIncorrecta: boolean = false;
  confirmarContrasenia: boolean = false;
  nombreError: boolean = false;
  apellidoError: boolean = false;
  turnoError: boolean = false;
  usuarioError: boolean = false;

  bedelData = {
    id: null, 
    nombre: '',
    apellido: '',
    turno: '',
    usuario: '',
    contrasenia: '',
    confirmarContrasenia: ''
  };

  constructor(private bedelService: BedelService) { }

  registrarBedelSubmit(event: Event) {
    event.preventDefault();
    if (this.chequearErrores() == true) return;


    const bedelDTO: BedelDTO = {
      nombre: this.bedelData.nombre,
      apellido: this.bedelData.apellido,
      turno: this.mapTurno(this.bedelData.turno),
      usuario: this.bedelData.usuario
    };

    this.bedelService.registrarBedel(bedelDTO).subscribe(
      response => {
        console.log('Bedel registrado con éxito', response);
      },
      error => {
        if (error.status == 409) this.usuarioExistente = true;
        console.error('Error al registrar el bedel', error);
      }
    );
  }

  chequearErrores() {
    this.nombreError = false;
    this.apellidoError = false;
    this.confirmarContrasenia = false;
    this.contraseniaIncorrecta = false;
    this.usuarioError = false;

    if (this.bedelData.nombre.length < 1) this.nombreError = true;
    if (this.bedelData.apellido.length < 1) this.apellidoError = true;
    if (this.bedelData.turno.length < 1) this.turnoError = true;
    if (this.bedelData.usuario.length < 1) this.usuarioError = true;
    if (this.bedelData.contrasenia.length < 8 || this.bedelData.contrasenia.length > 20) this.contraseniaIncorrecta = true;
    if (this.bedelData.contrasenia !== this.bedelData.confirmarContrasenia) this.confirmarContrasenia = true;
    if (this.confirmarContrasenia || this.contraseniaIncorrecta || this.nombreError || this.apellidoError || this.turnoError || this.usuarioError) return true;
    return false;
  }

  cancelarRegistro() {
    
  }

  mapTurno(turno: any) {
    console.log(turno);
    if (turno == 'maniana') return 1;
    else if (turno == 'tarde') return 2;
    else return 3;
  }
}
