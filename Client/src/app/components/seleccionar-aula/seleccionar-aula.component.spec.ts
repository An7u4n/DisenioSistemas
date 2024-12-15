import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeleccionarAulaComponent } from './seleccionar-aula.component';

describe('SeleccionarAulaComponent', () => {
  let component: SeleccionarAulaComponent;
  let fixture: ComponentFixture<SeleccionarAulaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SeleccionarAulaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SeleccionarAulaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
