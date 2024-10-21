import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import "cally";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrarBedelComponent } from './components/registrar-bedel/registrar-bedel.component';
import { FormsModule } from '@angular/forms';
import { TipoDuracionComponent } from './components/reserva/tipo-duracion/tipo-duracion.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    RegistrarBedelComponent,
    TipoDuracionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    
  ],
  providers: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
