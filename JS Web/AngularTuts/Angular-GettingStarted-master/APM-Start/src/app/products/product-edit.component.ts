import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'pm-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  productId: number;
  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit() {
    this.route.params.subscribe(
      params => {
        console.log(params['id']);
      }
    )
    //this.productId = +params[id];
  }

}
