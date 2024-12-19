import { Component, EventEmitter, HostListener, Input, Output, SimpleChange, SimpleChanges } from '@angular/core';
import { BedelService } from '../../services/bedel.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { BedelDTO } from '../../model/dto/BedelDTO';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-modificar-bedel',
  templateUrl: './modificar-bedel.component.html',
  styleUrl: './modificar-bedel.component.css'
})
export class ModificarBedelComponent {
  @Input() bedelActual!: BedelDTO;
  mostrarFormulario: boolean = true;
  desactivarUsuario: boolean = false;

  usuarioExistente: boolean = false;
  contraseniaIncorrecta: boolean = false;
  confirmarContrasenia: boolean = false;
  nombreError: boolean = false;
  apellidoError: boolean = false;
  turnoError: boolean = false;
  usuarioError: boolean = false;

  mostrarPopup: boolean = false;

  bedelActualizado!: FormGroup;

  @Output() mostrar: EventEmitter<boolean> = new EventEmitter<boolean>();
  
  constructor(private bedelService: BedelService, private toastr: ToastrService, private router: Router, private fb: FormBuilder) { }

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if(event.key === 'Enter') {
      this.modificarBedelSubmit(event);
    }
  }

  ngOnInit() {
    this.bedelActualizado = this.fb.group({
      nombre: [this.bedelActual.nombre, [Validators.required]],
      apellido: [this.bedelActual.apellido, [Validators.required]],
      usuario: [{value: this.bedelActual.usuario, disabled: true}, [Validators.required]],
      contrasenia: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
      confirmarContrasenia: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
      turno: [this.mapTurnoNumero(this.bedelActual.turno), [Validators.required]]
    });
  }

  
  modificarBedelSubmit(event: Event) {
    event.preventDefault();
    
    if(this.chequearErrores()) return;

    const bedelDTO: BedelDTO = {
      idBedel: this.bedelActual.idBedel,
      nombre: this.bedelActualizado.value.nombre,
      contrasena: this.bedelActualizado.value.contrasenia,
      apellido: this.bedelActualizado.value.apellido,
      turno: this.mapTurno(this.bedelActualizado.value.turno),
      usuario: this.bedelActualizado.get('usuario')?.value
    };

    
    this.bedelService.actualizarBedel(bedelDTO).subscribe(
      response => {
        console.log('Bedel modificado con éxito', response);
        this.toastr.success('El bedel fue modificado con éxito', 'Registro Exitoso', {
          timeOut: 2000, 
          closeButton: true,
          progressBar: true, 
        });
        setTimeout(() => {
          this.router.navigate(['/home']);
        }, 1000);
      },
      error => {
        if (error.status == 409) this.usuarioExistente = true;
        this.toastr.error('Ocurrió un error al modificar el bedel', 'Error');
      }
    );
  }

  chequearErrores() {
    this.nombreError = false;
    this.apellidoError = false;
    this.confirmarContrasenia = false;
    this.contraseniaIncorrecta = false;
    this.usuarioError = false;

    if (this.bedelActualizado.value.nombre.length < 1) this.nombreError = true;
    if (this.bedelActualizado.value.apellido.length < 1) this.apellidoError = true;
    if (this.bedelActualizado.value.turno.length < 1) this.turnoError = true;
    if (this.bedelActualizado.value.contrasenia.length < 8 || this.bedelActualizado.value.contrasenia.length > 20) this.contraseniaIncorrecta = true;
    if (this.bedelActualizado.value.contrasenia !== this.bedelActualizado.value.confirmarContrasenia) this.confirmarContrasenia = true;
    if (this.confirmarContrasenia || this.contraseniaIncorrecta || this.nombreError || this.apellidoError || this.turnoError || this.usuarioError) return true;
    return false;
  }

  mapTurno(turno: string) {
    if (turno == 'maniana') return 1;
    else if (turno == 'tarde') return 2;
    else return 3;
  }

  mapTurnoNumero(turno: number) : string {
    if (turno == 1) return 'maniana';
    else if (turno == 2) return 'tarde';
    else return 'noche';
  }

  volver() {
    this.mostrarPopup = !this.mostrarPopup;
  }

  cancelar() {
    this.mostrar.emit(false);
  }
}
