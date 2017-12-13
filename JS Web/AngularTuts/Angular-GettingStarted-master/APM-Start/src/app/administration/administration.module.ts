import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdministrationRoutingModule } from './administration-routing.module';
import { AdministrationComponent } from './administration.component';
import { AdministrationGuardService } from '../authentication/administration-guard.service';
import { ReactiveFormsModule } from '@angular/forms';
import { AdministrationService } from './administration-service';
import { RolesComponent } from './roles.component';

@NgModule({
  imports: [
    CommonModule,
    AdministrationRoutingModule,
    ReactiveFormsModule 
  ],
  declarations: [AdministrationComponent, RolesComponent],
  providers: [
    AdministrationGuardService,
    AdministrationService]

})
export class AdministrationModule { }
