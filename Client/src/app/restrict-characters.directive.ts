import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appRestrictCharacters]'
})
export class RestrictCharactersDirective {

  @Input('appRestrictCharacters') allowedChars: string = ''; 
  constructor(private el: ElementRef) {}
  @HostListener('input', ['$event']) onInput(event: InputEvent) {
    const inputElement = this.el.nativeElement as HTMLInputElement;

    // Remover caracteres no permitidos
    const regex = new RegExp(`[^${this.allowedChars}]`, 'g');
    const cleanedValue = inputElement.value.replace(regex, '');

    // Si el valor actual contiene caracteres inválidos, corrige el valor
    if (inputElement.value !== cleanedValue) {
      inputElement.value = cleanedValue;

      // Dispara el evento 'input' para notificar a Angular
      inputElement.dispatchEvent(new Event('input'));
    }
  }

  @HostListener('keypress', ['$event']) onKeyPress(event: KeyboardEvent) {
    const regex = new RegExp(`[${this.allowedChars}]`);
    // Si el carácter no es válido, prevenir la acción
    if (!regex.test(event.key)) {
      event.preventDefault();
    }
  }
}
