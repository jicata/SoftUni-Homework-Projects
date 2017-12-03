import { Component } from '@angular/core';
import { ProductService } from './products/product.service';

@Component({
  selector: "pm-root",
  templateUrl: "./app.component.html",
})
export class AppComponent {
  pageTitle: string = "Kurvi i belo";
}