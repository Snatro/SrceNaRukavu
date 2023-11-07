import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Person } from "../models/person.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn:'root'
})
export class PersonService {
  constructor(private http : HttpClient){}

  
  public getById(id : number) : Observable<Person>{
    return this.http.get<Person>(`https://localhost:7222/person/${id}`)
  }
}