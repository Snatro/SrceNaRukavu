import { Component, inject } from "@angular/core";
import { AuthService } from "src/app/services/auth.service";

@Component({
  selector:'app-navbar',
  templateUrl:'./navbar.component.html',
  styleUrls:['./navbar.component.css']
})
export class NavbarComponent {

  private auth = inject(AuthService);
  public isNotLogged : boolean = this.auth.isLoggedIn();
  public userName : string = this.isNotLogged ? this.auth.decodedToken().unique_name : '';
  public signOut() {
    this.auth.signOut();
  }
  constructor(){
    console.log(this.auth.decodedToken())
  }
}