import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ProductGuardService } from './product-guard.service';
import { ProductDetailComponent } from './product-detail.component';
import { ProductListComponent } from './product-list.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'products', component: ProductListComponent },
      {
        path: 'products/:id',
        canActivate: [ProductGuardService],
        component: ProductDetailComponent
      }
    ])
  ],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
