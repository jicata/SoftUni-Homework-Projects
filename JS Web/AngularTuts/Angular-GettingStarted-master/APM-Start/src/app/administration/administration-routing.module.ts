import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdministrationComponent } from './administration.component';
import { AdministrationGuardService } from '../authentication/administration-guard.service';

const routes: Routes = [
  {path:'administration', component: AdministrationComponent,  canActivate: [ AdministrationGuardService ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrationRoutingModule { }
