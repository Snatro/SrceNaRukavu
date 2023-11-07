import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public payload: any;

  constructor(private http: HttpClient, private router: Router) {
    this.payload = this.decodedToken();
  }

  public signUpUser(data: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(`https://localhost:7222/person`, data).subscribe({
        next: (response) => {
          window.location.replace('login');
          resolve(response);
        },
        error: (error) => {
          reject(error);
        },
      });
    });
  }

  public loginUser(data: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http
        .post<any>(`https://localhost:7222/person/login`, data)
        .subscribe({
          next: (response) => {
            this.storeToken(response.token);
            this.storeRole(response.role);
            this.payload = this.decodedToken();
            window.location.replace('ana');
            resolve(response);
          },
          error: (error) => {
            reject(error);
          },
        });
    });
  }

  public signOut() {
    localStorage.clear();
    window.location.replace('login');
  }

  public storeToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue);
  }

  public storeRole(roleValue: string) {
    localStorage.setItem('role', roleValue);
  }

  public getRole() {
    return localStorage.getItem('role');
  }

  public getToken() {
    return localStorage.getItem('token');
  }

  public isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  public decodedToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    return jwtHelper.decodeToken(token);
  }
}
