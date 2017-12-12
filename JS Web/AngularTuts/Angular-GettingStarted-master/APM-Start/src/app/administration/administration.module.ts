import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdministrationRoutingModule } from './administration-routing.module';
import { AdministrationComponent } from './administration.component';
import { AdministrationGuardService } from '../authentication/administration-guard.service';

@NgModule({
  imports: [
    CommonModule,
    AdministrationRoutingModule
  ],
  declarations: [AdministrationComponent],
  providers: [AdministrationGuardService]

})
export class AdministrationModule { }
