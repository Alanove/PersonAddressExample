import { Component, OnInit, Input,Output, EventEmitter } from '@angular/core';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrls: ['./person-details.component.scss']
})
export class PersonDetailsComponent implements OnInit {

  @Input() person:any;
  @Output() refreshData  = new EventEmitter();

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
  }
  save(){
    if(!this.person.firstName){
      alert("First Name is empty");
      return;
    }
    if(!this.person.lastName){
      alert("Last  Name is empty");
      return;
    }
    this.personService.savePerson(this.person).subscribe(persons => {
      this.refreshData.next();
      alert("Saved");
    });
  }
}
