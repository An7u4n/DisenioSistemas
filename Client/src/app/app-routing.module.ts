import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrarBedelComponent } from './components/registrar-bedel/registrar-bedel.component';
import { TipoDuracionComponent } from './components/reserva/tipo-duracion/tipo-duracion.component';

const routes: Routes = [
  {path: '', component: RegistrarBedelComponent, pathMatch: 'full'},
  {path: 'registrar-reserva', component: TipoDuracionComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
