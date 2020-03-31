import { PersonaService } from './../../services/persona.service';
import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';


@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  persona: Persona;
  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.persona = new Persona();
  }

  add(){
    this.personaService.post(this.persona).subscribe(p => {
      if(p!=null){
        alert('Persona creada!'+" Sus pulsaciones son: "+p.pulsacion);
        this.persona = p;
      }else{
        alert("La identificacion que intentas registrar ya se encuntra en uso");
      }
    });
  }
  
}
