import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioCargo } from './formulario-cargo';

describe('FormularioCargo', () => {
  let component: FormularioCargo;
  let fixture: ComponentFixture<FormularioCargo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormularioCargo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioCargo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
