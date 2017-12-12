import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { ActivatedRouteSnapshot } from '@angular/router/src/router_state';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class AdministrationGuardService implements CanActivate {
  constructor(private router: Router, private authService: AuthenticationService) { }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    debugger;
    let res= false;
    let userId = window.localStorage.getItem("userId");
    if(!userId){
      return false;
    }
    // let kur =  this.authService.isUserInRole(userId, "administrator")
    //   .map(data => res = data);
    let win = this.authService.isUserInRole(userId, "administrator");
    return res;
  }

}
