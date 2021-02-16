import { Component, OnInit } from '@angular/core';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})
export class PersonComponent implements OnInit {
  title:string = "Person";
  persons:any;
  selectedPerson:any;

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.getPersons();
  }
  getPersons(): void{
      this.personService.getPersons().subscribe(persons => {
        this.persons = persons;
      });
  }
  edit(person:any):void{
    this.selectedPerson = person;
  }
  createPerson():void{
    this.selectedPerson = {personId: 0};
  }
  delete(person:any):void{
    let personId = person.personId;
    if(confirm(`Are you sure you want to delete ${person.firstName} ${person.lastName}?`)){
      this.personService.deletePerson(personId).subscribe(p => {
        this.getPersons();
      });
    }
  }
}
