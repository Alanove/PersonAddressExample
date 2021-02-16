import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import {environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  private apiUrl = "Address";

  constructor(private http: HttpClient) { 
    this.apiUrl = `${environment.apiURL}${this.apiUrl}`;
  }

  getAddresses():Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/addresses`);
  }
  getPersonAddresses(personId:number):Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/${personId}`);
  }

  saveAddress(address:any):Observable<any>{
    return this.http.put<any>(`${this.apiUrl}/Update`, address);
  }
  createAddress(address:any):Observable<any>{
    return this.http.put<any>(`${this.apiUrl}/Create`, address);
  }
  deleteAddress(addressId:any):Observable<any>{
    return this.http.delete<any>(`${this.apiUrl}/Delete/${addressId}`);
  }
}
