import { Component, EventEmitter, Inject, OnInit, Output, inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Product } from 'src/app/models/product.model';
import { ClothesFormComponent } from '../clothes-form/clothes-form.component';
import { ProductService } from 'src/app/services/product.service';
import { AuthService } from 'src/app/services/auth.service';
import { Reservation } from 'src/app/models/reservation.model';
import { PersonService } from 'src/app/services/person.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { Subject, takeUntil } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-cloth-info',
  templateUrl: './cloth-info.component.html',
  styleUrls: ['./cloth-info.component.css']
})
export class ClothInfoComponent implements OnInit {
  private dialog = inject(MatDialog);
  private productService = inject(ProductService);
  private auth = inject(AuthService);
  private personService = inject(PersonService);
  private reservationService = inject(ReservationService);
  private snackBar = inject(MatSnackBar);
  
  public product: Product;
  @Output() public closed: EventEmitter<any> = new EventEmitter();

  private destroy = new Subject<boolean>();
  
  public hideButtons() : boolean {
    console.log(this.auth.decodedToken().role)
    return this.auth.decodedToken().role === '4';
  }
  constructor( private dialogRef: MatDialogRef<ClothInfoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.product = this.data.product;
  }

  public reserve(){
    if(!this.auth.isLoggedIn()){
      console.log("Cannot reserve without logging in! Please try again..");
      return;
    }

    let reservation : Reservation = new Reservation;
    let id: number = this.auth.decodedToken().Id;
    this.personService.getById(id).subscribe((person) => {
      console.log(person)
      reservation.person = person;
      reservation.product = this.product;
      this.reservationService.makeReservation(reservation).subscribe(() => {
        this.snackBar.open("Reservation complete!");
        window.location.reload()
      })
    })
   
  }

  public delete(){
    this.productService.deleteProduct(this.product.id).subscribe(()=>{
      this.closed.emit(true);
      this.dialogRef.close();
    });
  }

  public edit(){
    console.log(this.product);
    const dialogRef = this.dialog.open(ClothesFormComponent, {
      data:{sectionId: this.product.section.id, product:this.product}
    })
    dialogRef.componentInstance.closed
    .pipe(takeUntil(this.destroy))
    .subscribe((result: any) => {
      if (result === true) {
        window.location.reload();
        this.snackBar.open(this.product.name + ' cloth has been edited')
      }
    });
    
  }

  public exit(){
    this.dialogRef.close();
  }
}
