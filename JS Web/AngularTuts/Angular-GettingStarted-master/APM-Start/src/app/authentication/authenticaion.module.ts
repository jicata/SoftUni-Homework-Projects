import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { LoginComponent } from './login.component';
import { SharedModule } from '../shared/shared.module';
import { AuthenticationRoutingModule } from './authentication-router.module';

@NgModule({
    imports: [
        SharedModule,
        AuthenticationRoutingModule,
        ReactiveFormsModule
    ],
    declarations: [
        LoginComponent
    ],
    providers: [],
})
export class AuthenticationModule { }
