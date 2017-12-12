import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Login } from './login';

import 'rxjs/add/operator/debounceTime';
import { AuthenticationService } from './authentication.service';

@Component({
  selector: 'pm-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  user: Login = new Login()
  pageTitle: string = "Login";
  errorMessages: {}
  validationMessages = {
    required: 'Field is required'
  }

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthenticationService,
    private router: Router) {
    this.errorMessages = {};
   }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })

    this.subscribeAllFormControlsToErrorMessage(this.loginForm);
  }

  loginUser(): void {
       this.authService.loginUser(this.loginForm.value)
         .subscribe(
           response => this.saveCredentials(response),
           error => console.log('ERROR!!!! ' + error )
         )
  }

  subscribeAllFormControlsToErrorMessage(form: FormGroup): void {
    for (let item in form.controls) {
      let control = form.controls[item];
      if ((control as FormGroup).controls) {
        this.subscribeAllFormControlsToErrorMessage((control as FormGroup));
      }
      control.valueChanges.debounceTime(1001).subscribe(value =>
        this.setMessage(control, item));
    }
  }

  setMessage(c: AbstractControl, name: string): void {
    this.errorMessages[name] = ''
    if ((c.touched || c.dirty) && c.errors) {
      this.errorMessages[name] = Object.keys(c.errors).map(key =>
        this.validationMessages[key]).join(' ');
    }
  }

  saveCredentials(response: any): void{
    window.localStorage.setItem('authtoken', response._kmd.authtoken);
    this.authService.setIdAndRole(response);
    this.router.navigate(['/welcome'])  
  }

}
