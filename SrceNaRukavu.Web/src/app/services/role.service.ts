import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Role } from "../models/role.model";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class RoleService{
  constructor(private http: HttpClient){}

  public getRoles() : Observable<Role[]> {
    return this.http.get<Role[]>(`https://localhost:7222/role`)
  }
}