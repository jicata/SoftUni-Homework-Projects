import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ProductGuardService } from './product-guard.service';
import { ProductDetailComponent } from './product-detail.component';
import { ProductListComponent } from './product-list.component';
import { ProductEditComponent } from './product-edit.component';
import { AdministrationGuardService } from '../authentication/administration-guard.service';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'products', component: ProductListComponent },
      {
        path: 'products/:id',
        component: ProductDetailComponent
      },
      {
        path: 'edit/:id',
        canActivate: [AdministrationGuardService],
        component: ProductEditComponent
      },
      {
        path: 'create',
        canActivate: [AdministrationGuardService],
        component: ProductEditComponent
      }
    ])
  ],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
