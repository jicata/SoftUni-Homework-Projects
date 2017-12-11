import { Component} from '@angular/core';
import { ProductService } from './products/product.service';
import { Router } from '@angular/router';

@Component({
  selector: "pm-root",
  templateUrl: "./app.component.html",
})
export class AppComponent {
  pageTitle: string = "Belvi Products";
  
constructor(private router: Router){

}

  userIsLoggedIn(): boolean{
    return window.localStorage.authtoken !== undefined;
  }

  logout(e){
    debugger;
    window.localStorage.clear();
    this.router.navigate(['/welcome'])
    
  }

 
}