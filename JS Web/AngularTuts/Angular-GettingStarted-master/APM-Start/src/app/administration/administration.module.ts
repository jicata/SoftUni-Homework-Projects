import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdministrationRoutingModule } from './administration-routing.module';
import { AdministrationComponent } from './administration.component';
import { AdministrationGuardService } from '../authentication/administration-guard.service';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    AdministrationRoutingModule,
    ReactiveFormsModule 
  ],
  declarations: [AdministrationComponent],
  providers: [AdministrationGuardService]

})
export class AdministrationModule { }
