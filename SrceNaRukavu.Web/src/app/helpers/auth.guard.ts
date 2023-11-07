import { Injectable } from "@angular/core";
import { ActivatedRoute, ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AuthService } from "../services/auth.service";
import { Roles } from "../consts/role.enums";
@Injectable({
  providedIn:'root'
})
export class AuthGuard implements CanActivate{

  constructor(private authService: AuthService, private router: ActivatedRoute) {}
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const roleId = this.authService.decodedToken().role || Roles.CUSTOMER;
    if(roleId !== Roles.CUSTOMER){
      return true;
    }
    return false;
  }

}