import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrarBedelComponent } from './components/registrar-bedel/registrar-bedel.component';
import { TipoDuracionComponent } from './components/reserva/tipo-duracion/tipo-duracion.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {path: 'registrar-bedel', component: RegistrarBedelComponent, pathMatch: 'full'},
  {path: 'login', component: LoginComponent, pathMatch: 'full'},
  {path: 'registrar-reserva', component: TipoDuracionComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
