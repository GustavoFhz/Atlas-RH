import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesDepartamento } from './detalhes-departamento';

describe('DetalhesDepartamento', () => {
  let component: DetalhesDepartamento;
  let fixture: ComponentFixture<DetalhesDepartamento>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetalhesDepartamento]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetalhesDepartamento);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
