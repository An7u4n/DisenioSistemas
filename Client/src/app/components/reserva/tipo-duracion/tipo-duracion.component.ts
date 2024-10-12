import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';

@Component({
  selector: 'app-tipo-duracion',
  templateUrl: './tipo-duracion.component.html',
  styleUrl: './tipo-duracion.component.css'
})
export class TipoDuracionComponent {
  @ViewChild('calendar', { static: true }) calendarElement!: ElementRef;

  constructor(private renderer: Renderer2) {}

  ngAfterViewInit(): void {
    const calendarNativeElement = this.calendarElement.nativeElement;
    const shadowRoot = calendarNativeElement.shadowRoot;

    if (shadowRoot) {
      const headingPart = shadowRoot.querySelector('[part="heading"]');
      const divChild = headingPart.querySelector('div');
      console.log(shadowRoot);
      console.log(headingPart);
      this.renderer.setStyle(divChild, 'position', 'relative');
      this.renderer.setStyle(divChild, 'left', '-178px');
    }
  }
  
  submitTipoReserva(event: Event) {
    event.preventDefault();
    console.log('Tipo de reserva seleccionado');
  }
}
