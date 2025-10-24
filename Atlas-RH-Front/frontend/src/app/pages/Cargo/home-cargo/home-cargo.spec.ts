import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeCargo } from './home-cargo';

describe('HomeCargo', () => {
  let component: HomeCargo;
  let fixture: ComponentFixture<HomeCargo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeCargo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeCargo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
