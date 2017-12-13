import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdministrationComponent } from './administration.component';
import { AdministrationGuardService } from '../authentication/administration-guard.service';
import { RolesComponent } from './roles.component';

const routes: Routes = [
  { path: 'roles', component: RolesComponent, canActivate: [AdministrationGuardService] },
  { path: 'administration', component: AdministrationComponent, canActivate: [AdministrationGuardService] },
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrationRoutingModule { }
