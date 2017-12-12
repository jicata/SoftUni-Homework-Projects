import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { ActivatedRouteSnapshot } from '@angular/router/src/router_state';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AdministrationGuardService implements CanActivate {
  private isAdmin: boolean = false;
  constructor(private router: Router, private authService: AuthenticationService) { }

  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> | boolean{
    let res = false;
    let userId = window.localStorage.getItem("userId");
    if (!userId) {
      this.router.navigate(['/login']);
      return false;
    }
    return this.isUserAdmin(userId)
  }

  isUserAdmin(userId: string) {
    return this.authService.isUserInRole(userId, "administrator")
      .map(result => {
        if(result){
          return true;
        }
      });
  }
}
