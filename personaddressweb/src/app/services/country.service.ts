import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import {environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  private apiUrl = "Country";

  constructor(private http: HttpClient) { 
    this.apiUrl = `${environment.apiURL}${this.apiUrl}`;
  }

  getCountries():Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/countries`);
  }
}
