import { Component } from '@angular/core';

@Component({
  selector: 'app-registrar-bedel',
  templateUrl: './registrar-bedel.component.html',
  styleUrl: './registrar-bedel.component.css'
})
export class RegistrarBedelComponent {
  usuarioExistente: boolean = false;
  contraseniaIncorrecta: boolean = false;
  confirmarContrasenia: boolean = false;

  registrarBedelSubmit(event: Event) {
    event.preventDefault();
  }
}
