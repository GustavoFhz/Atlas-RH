import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesCargo } from './detalhes-cargo';

describe('DetalhesCargo', () => {
  let component: DetalhesCargo;
  let fixture: ComponentFixture<DetalhesCargo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetalhesCargo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetalhesCargo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
