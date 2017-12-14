import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Response, Headers } from '@angular/http';
import { Router } from '@angular/router';

import 'rxjs/add/operator/debounceTime';


import { AuthenticationService } from './authentication.service';
import { Register } from './register';

function emailMatcher(c: AbstractControl): { [key: string]: boolean } | null {
  let passwordControl = c.get('email');
  let confirmPasswordControl = c.get('confirmEmail');
  if (passwordControl.pristine || confirmPasswordControl.pristine) {
    return null;
  }
  if (passwordControl.value == confirmPasswordControl.value) {
    return null;
  }
  return { 'match': true };
}

@Component({
  selector: 'pm-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  private pageTitle: string = "Register"
  errorMessages: {}
  private validationMessages = {
    required: 'Field is required',
    pattern: 'Please enter valid input',
    match: 'Input fields must match'
  }

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router) {
    this.errorMessages = {};
  }

  ngOnInit() {

    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      emailGroup: this.formBuilder.group({
        email: ['', [Validators.required,Validators.pattern('[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+')]],
        confirmEmail: ['', Validators.required]
      }, { validator: emailMatcher }),
      password: ['', Validators.required],
    })

    this.subscribeAllFormControlsToErrorMessage(this.registerForm);
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

  registerUser(): void {
    var postData = this.registerForm.value;
    let isUserValid = this.validateRegistration(postData);
    if (!isUserValid) {
      alert("One or more invalid fields");
      this.registerForm.reset();
      this.router.navigate(['/register']);
      return;
    }
    var newUser = {
      username: postData.username,
      password: postData.password,
      email: postData.emailGroup.email,
    };

    this.authenticationService.registerUser(newUser)
      .subscribe(
      (result) => { this.handleResponse(result) },
      (error: any) => console.log(error)
      )
  }

  handleResponse(response: any): void {
    window.localStorage.setItem('authtoken', response._kmd.authtoken);
    this.authenticationService.setIdAndRole(response);
    this.router.navigate(['/welcome'])
  }

  validateRegistration(postData: any): boolean {
    
    if (!postData.emailGroup.email
      || !postData.emailGroup.confirmEmail
      || !postData.username
      || !postData.password) {
      return false;
    }
    if (postData.emailGroup.email.length == 0
      || postData.emailGroup.confirmEmail.length == 0
      || (postData.emailGroup.confirmEmail !== postData.emailGroup.email)) {
      return false;
    }
    if(!postData.emailGroup.email.match(/[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+/)){
      return false;
    }
    if (postData.username.length == 0 || postData.password == 0) {
      return false;
    }
    return true;
  }
}
