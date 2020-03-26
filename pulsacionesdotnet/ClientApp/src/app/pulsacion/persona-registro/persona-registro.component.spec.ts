import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonaRegistroComponent } from './persona-registro.component';

describe('PersonaRegistroComponent', () => {
  let component: PersonaRegistroComponent;
  let fixture: ComponentFixture<PersonaRegistroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonaRegistroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonaRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
