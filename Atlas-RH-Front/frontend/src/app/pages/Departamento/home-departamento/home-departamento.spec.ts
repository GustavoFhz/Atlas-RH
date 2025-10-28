import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeDepartamento } from './home-departamento';

describe('HomeDepartamento', () => {
  let component: HomeDepartamento;
  let fixture: ComponentFixture<HomeDepartamento>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeDepartamento]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeDepartamento);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
