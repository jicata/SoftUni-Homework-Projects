import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { IProduct } from './product';
import { ProductService } from './product.service';


@Component({
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: IProduct;
  pageTitle: string = 'Product Detail'
  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router) {

  }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');
    this.productService.getProducts()
      .subscribe(data => {
        this.product = data.filter(p => p.productId == id)[0]
      })
  }

  onBack(): void {
    this.router.navigate(['/products']);
  }
}
