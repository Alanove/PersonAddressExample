import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import {environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private apiUrl = "Person";

  constructor(private http: HttpClient) { 
    this.apiUrl = `${environment.apiURL}${this.apiUrl}`;
  }


  getPersons():Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/All`);
  }

  savePerson(person:any):Observable<any>{
    return this.http.put<any>(`${this.apiUrl}/Update`, person);
  }
  createPerson(person:any):Observable<any>{
    return this.http.put<any>(`${this.apiUrl}/Create`, person);
  }
  deletePerson(personId:any):Observable<any>{
    return this.http.delete<any>(`${this.apiUrl}/Delete/${personId}`);
  }
}
