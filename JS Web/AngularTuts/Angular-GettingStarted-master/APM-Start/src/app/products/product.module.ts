import { NgModule } from '@angular/core';

import { ProductListComponent } from './product-list.component';
import { ProductDetailComponent } from './product-detail.component';
import { ProductGuardService } from './product-guard.service';
import { ProductService } from './product.service';

import { SharedModule } from './../shared/shared.module';
import { ProductRoutingModule } from './product-routing.module';
import { ProductEditComponent } from './product-edit.component';

@NgModule({
  imports: [
    SharedModule,
    ProductRoutingModule
  ],
  declarations: [
    ProductListComponent,
    ProductDetailComponent,
    ProductEditComponent,
  ],
  providers: [
    ProductService,
    ProductGuardService],    
})
export class ProductModule { }
