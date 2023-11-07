import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../models/product.model";
import { Category } from "../models/category.model";

@Injectable({
  providedIn:'root'
})
export class CategoryService {
  
  constructor(private http: HttpClient){}

  public get() : Observable<Category[]> {
    return this.http.get<Category[]>(`https://localhost:7222/category`);
  }
  public getById(id: number) : Observable<Category> {
    return this.http.get<Category>(`https://localhost:7222/category/${id}`);
  }
}