import { Component, OnInit } from '@angular/core';
import { AddressService } from '../services/address.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {
  title: string = "Address";
  addresses:any;
  selectedAddress:any;
  personId:number = -1;

  constructor(private addressService:AddressService,
    private route: ActivatedRoute,
  private router: Router) { }

  ngOnInit(): void {
    
    this.getAddresses();
  }

  getAddresses(): void{
    let temp = this.route.snapshot.paramMap.get('personId');
    if(temp)
      this.personId = parseInt(temp);

      console.log(this.personId);
    
      if(this.personId != -1){
        this.addressService.getPersonAddresses(this.personId).subscribe(addresses => {
          this.addresses = addresses;
        });
      }
      else{
        this.addressService.getAddresses().subscribe(addresses => {
          this.addresses = addresses;
        });
      }
  }
  edit(address:any):void{
    this.selectedAddress = address;
  }
  createAddress():void{
    this.selectedAddress = {addressId: 0};
  }
  delete(address:any):void{
    debugger;
    let addressId = address.addressId;
    if(confirm(`Are you sure you want to delete ${address.addressLine1}?`)){
      this.addressService.deleteAddress(addressId).subscribe(a => {
        this.getAddresses();
      });
    } 
  }
}
