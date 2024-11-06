import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import "cally";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrarBedelComponent } from './components/registrar-bedel/registrar-bedel.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { TipoDuracionComponent } from './components/reserva/tipo-duracion/tipo-duracion.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SeleccionReservaComponent } from './components/reserva/seleccion-reserva/seleccion-reserva.component';
import { BuscarBedelComponent } from './components/buscar-bedel/buscar-bedel.component';
import { PeriodicaComponent } from './components/reserva/periodica/periodica.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrarBedelComponent,
    TipoDuracionComponent,
    LoginComponent,
    HomeComponent,
    SeleccionReservaComponent,
    BuscarBedelComponent,
    PeriodicaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ReactiveFormsModule
  ],
  providers: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
