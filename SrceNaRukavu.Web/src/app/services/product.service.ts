import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { CreateProduct } from '../models/create-product.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient){

  }

  getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>('https://localhost:7222/product');
  }

  addProduct(product: any) : Observable<any>{
    return this.http.post('https://localhost:7222/product', product);
  }

  updateProduct(product: any) : Observable<any>{
    return this.http.put('https://localhost:7222/product', product);
  }
  deleteProduct(id: number): Observable<any>{
    return this.http.delete(`https://localhost:7222/product/${id}`)
  }
}