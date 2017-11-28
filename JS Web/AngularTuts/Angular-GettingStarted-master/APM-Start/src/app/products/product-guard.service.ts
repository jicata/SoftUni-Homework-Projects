import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { ActivatedRouteSnapshot } from '@angular/router/src/router_state';

@Injectable()
export class ProductGuardService implements CanActivate {
  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    let id = +route.url[1].path;
    if (isNaN(id) || id < 1) {
      alert("invalid product id bitch kurvata");
      this.router.navigate(['/products']);
      return false;
    }
    return true;
  }

}
