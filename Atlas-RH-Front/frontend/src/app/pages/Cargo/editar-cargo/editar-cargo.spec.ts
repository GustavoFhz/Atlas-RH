import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarCargo } from './editar-cargo';

describe('EditarCargo', () => {
  let component: EditarCargo;
  let fixture: ComponentFixture<EditarCargo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditarCargo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditarCargo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
