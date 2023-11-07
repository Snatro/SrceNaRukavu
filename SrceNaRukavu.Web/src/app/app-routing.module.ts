import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ClothesGridComponent } from './components/clothes-grid/clothes-grid.component';
import { ClothesFormComponent } from './components/clothes-form/clothes-form.component';
import { LoginComponent } from './components/login/login.component';
import { PersonFormComponent } from './components/person-form/person-form.component';
import { ReservationListComponent } from './components/reservation-list/reservation-list.component';
import { AuthGuard } from './helpers/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/ana', pathMatch: 'full' },
  { path: 'ana', component: ClothesGridComponent, data: { sectionId: 1 } },
  {
    path: 'prijatelj',
    component: ClothesGridComponent,
    data: { sectionId: 2 },
  },
  { path: 'clothes-form', component: ClothesFormComponent, canActivate:[AuthGuard]},
  {path: 'login', component:LoginComponent},
  {path: 'register', component:PersonFormComponent},
  {path: 'rezervacije', component:ReservationListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{onSameUrlNavigation:'reload'})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
