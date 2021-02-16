import { Component, OnInit, Input,Output, EventEmitter } from '@angular/core';
import { PersonService } from '../services/person.service';
import { AddressService } from '../services/address.service';
import { CountryService } from '../services/country.service';

@Component({
  selector: 'app-address-details',
  templateUrl: './address-details.component.html',
  styleUrls: ['./address-details.component.scss']
})
export class AddressDetailsComponent implements OnInit {
  @Input() address:any;
  @Output() refreshData  = new EventEmitter();

  countries:any;
  persons:any;

  constructor(
    private personService: PersonService,
    private countryService: CountryService,
    private addressService: AddressService
  ) { }

  ngOnInit(): void {
    this.personService.getPersons().subscribe(persons => {
      this.persons = persons;
    });
    this.countryService.getCountries().subscribe(countries => {
      this.countries = countries;
    });
  }


  save(){
    if(!this.address.personId){
      alert("Please select a person");
      return;
    }
    if(!this.address.addressLine1){
      alert("Address Line 1 is empty");
      return;
    }
    if(!this.address.countryCode){
      alert("Please select a country.");
      return;
    }

    this.addressService.saveAddress(this.address).subscribe(addresses => {
      this.refreshData.next();
      alert("Saved");
    });
  }
}
