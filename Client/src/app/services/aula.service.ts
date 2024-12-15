import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AulaService {
  private aulas: any;
  setAulas(aulas: any) {
    this.aulas = aulas;
  }

  getAulas() {
    return this.aulas;
  }
}
