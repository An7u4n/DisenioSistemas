import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrarBedelComponent } from './components/registrar-bedel/registrar-bedel.component';
import { TipoDuracionComponent } from './components/reserva/tipo-duracion/tipo-duracion.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { LoginGuard } from './guards/login.guard';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent, pathMatch: 'full', canActivate: [LoginGuard]},
  {path: 'registrar-bedel', component: RegistrarBedelComponent, pathMatch: 'full', canActivate: [LoginGuard]},
  {path: 'registrar-reserva', component: TipoDuracionComponent, pathMatch: 'full', canActivate: [LoginGuard]},
  {path: 'login', component: LoginComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
