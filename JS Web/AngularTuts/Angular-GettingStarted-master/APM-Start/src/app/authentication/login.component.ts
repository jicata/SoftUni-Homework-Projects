import { Component, OnInit } from '@angular/core';

import { FormGroup,FormBuilder, Validators } from '@angular/forms';
import { Login } from './login';

@Component({
  selector: 'pm-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  user: Login = new Login()
  pageTitle: string = "Login";
  errorMessage:{}

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.errorMessage = {};
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['']
    })
  }

  loginUser(): void{
    console.log('Kurvii: ' + JSON.stringify(this.loginForm.value));
  }

}
