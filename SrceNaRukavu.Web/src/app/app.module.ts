import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClothesFormComponent } from './components/clothes-form/clothes-form.component';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzAutocompleteModule } from 'ng-zorro-antd/auto-complete';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { uk_UA } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import uk from '@angular/common/locales/uk';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClothesGridComponent } from './components/clothes-grid/clothes-grid.component';
import { DialogModule, DialogService } from '@progress/kendo-angular-dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogConfig, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import {MatGridListModule} from '@angular/material/grid-list';
import { ClothInfoComponent } from './components/cloth-info/cloth-info.component';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import { TokenInterceptor } from './components/interceptors/token.interceptor';
import { LoginComponent } from './components/login/login.component';
import { PersonFormComponent } from './components/person-form/person-form.component';
import { ReservationListComponent } from './components/reservation-list/reservation-list.component';
import { GuiGridModule } from '@generic-ui/ngx-grid';
import {MAT_SNACK_BAR_DEFAULT_OPTIONS, MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';

registerLocaleData(uk);
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ClothesFormComponent,
    ClothesGridComponent,
    ClothInfoComponent,
    LoginComponent,
    PersonFormComponent,
    ReservationListComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    AppRoutingModule,
    RouterModule,
    FormsModule,
    NzFormModule,
    NzAutocompleteModule,
    NzInputNumberModule,
    NzUploadModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    DialogModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatGridListModule,
    MatCardModule,
    MatIconModule,
    GuiGridModule,
    MatSnackBarModule
  ],
  providers: [{ provide: NZ_I18N, useValue: uk_UA },  {provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: {duration: 2500}},MatDialogConfig, {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}
