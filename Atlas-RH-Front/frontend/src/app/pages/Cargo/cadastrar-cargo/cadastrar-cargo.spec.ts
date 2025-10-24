import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarCargo } from './cadastrar-cargo';

describe('CadastrarCargo', () => {
  let component: CadastrarCargo;
  let fixture: ComponentFixture<CadastrarCargo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CadastrarCargo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastrarCargo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
