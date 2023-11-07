import { Component, OnInit, inject } from '@angular/core';
import { Product } from '../../models/product.model';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute } from '@angular/router';
import { ClothesFormComponent } from '../clothes-form/clothes-form.component';
import { Subject, takeUntil } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ClothInfoComponent } from '../cloth-info/cloth-info.component';
import { AuthService } from 'src/app/services/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-clothes-grid',
  templateUrl: './clothes-grid.component.html',
  styleUrls: ['./clothes-grid.component.css'],
})
export class ClothesGridComponent implements OnInit {
  public sectionId: any;
  public products: Product[];
  private productService = inject(ProductService);
  private route = inject(ActivatedRoute);
  private dialog = inject(MatDialog);
  private auth = inject(AuthService);
  private snackBar = inject(MatSnackBar)

  private destroy = new Subject<boolean>();

  ngOnInit(): void {
    this.hiddenButton();
    this.route.data.subscribe((data) => {
      this.sectionId = data['sectionId'];
    }).unsubscribe;
    this.productService.getProducts().subscribe((products) => {
      this.products = products.filter(
        (product) => product.section.id === this.sectionId
      );
    });
  }

  public hiddenButton(): boolean {
    if (this.auth.isLoggedIn()) {
      let userRoleId = this.auth.decodedToken().role;
      if (userRoleId !== '4') {
        return false;
      }
    }
    return true;
  }

  public addNewCloth() {
    const dialogRef = this.dialog.open(ClothesFormComponent, {
      width: '60%',
      height: '400px',
      data: { sectionId: this.sectionId },
    });

    dialogRef.componentInstance.closed
      .pipe(takeUntil(this.destroy))
      .subscribe((result: any) => {
        if (result === true) {
          this.snackBar.open('New cloth just added!')
          window.location.reload();
        }
      });
  }

  public seeInfo(product: Product) {
    const dialogRef = this.dialog.open(ClothInfoComponent, {
      data: { product: product },
      disableClose: true,
    });
    dialogRef.componentInstance.closed
      .pipe(takeUntil(this.destroy))
      .subscribe((result: any) => {
        if (result === true) {
          this.snackBar.open('Cloth has been deleted')
          window.location.reload();
        }
      });
  }
}
