import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GuiCellView, GuiColumn, GuiDataType } from '@generic-ui/ngx-grid';
import { Subject, take, takeUntil, takeWhile } from 'rxjs';
import { Reservation } from 'src/app/models/reservation.model';
import { ReservationDTO } from 'src/app/models/reservationDTO';
import { AuthService } from 'src/app/services/auth.service';
import { ProductService } from 'src/app/services/product.service';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.css']
})
export class ReservationListComponent implements OnInit {

  public reservations : ReservationDTO[] = [];

  private destroy = new Subject<boolean>();

  public hideButton() : boolean {
    return this.auth.decodedToken().role === '4';
  }

  constructor(private reservationService: ReservationService, private auth: AuthService, private snackBar : MatSnackBar,private productService: ProductService) { }

  ngOnInit(): void {
    if(this.auth.isLoggedIn()){
      if(this.auth.decodedToken().role === '4'){
      let id : number = this.auth.decodedToken().Id;
      this.reservationService.getReservationsByPersonId(id).subscribe((result: ReservationDTO[]) => {
        this.reservations = result;
      })
    }
    else{
      this.reservationService.getReservations().pipe(takeUntil(this.destroy)).subscribe((result: ReservationDTO[]) => {
        this.reservations = result;
      })
    }
  }
  }

  public removeReservation(id: number){
    this.reservationService.deleteReservation(id).pipe(takeUntil(this.destroy)).subscribe(() =>{
      window.location.reload();
      this.snackBar.open('Reservation removed')
    })
  }

  public deleteReservation(productId: number){
    this.productService.deleteProduct(productId).pipe(take(1)).subscribe(() => {
      window.location.reload();
      this.snackBar.open('Reservation deleted!');
    })
  }
}
