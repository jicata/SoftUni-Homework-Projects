import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { LoginComponent } from './login.component';
import { SharedModule } from '../shared/shared.module';
import { AuthenticationRoutingModule } from './authentication-router.module';
import { RegisterComponent } from './register.component';
import { AuthenticationService } from './authentication.service';

@NgModule({
    imports: [
        SharedModule,
        AuthenticationRoutingModule,
        ReactiveFormsModule
    ],
    declarations: [
        LoginComponent,
        RegisterComponent
    ],
    providers: [AuthenticationService],
})
export class AuthenticationModule { }
