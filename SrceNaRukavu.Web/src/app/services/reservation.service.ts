import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Reservation } from "../models/reservation.model";
import { ReservationDTO } from "../models/reservationDTO";

@Injectable({
  providedIn:'root'
})
export class ReservationService{

  constructor(private http: HttpClient){}

  public getReservations() : Observable<ReservationDTO[]>{
    return this.http.get<ReservationDTO[]>(`https://localhost:7222/reservation`);
  }

  public getReservationsByPersonId(id : number) : Observable<ReservationDTO[]>{
    return this.http.get<ReservationDTO[]>(`https://localhost:7222/reservation/person/${id}/reservations`);
  }

  public getReservationId(id : number) : Observable<ReservationDTO>{
    return this.http.get<ReservationDTO>(`https://localhost:7222/reservation/${id}`);
  }

  public makeReservation(model: any) : Observable<any> {
    return this.http.post(`https://localhost:7222/reservation`,model);
  }

  public deleteReservation(id: number) : Observable<any>{
    return this.http.delete(`https://localhost:7222/reservation/${id}`);
  }
}