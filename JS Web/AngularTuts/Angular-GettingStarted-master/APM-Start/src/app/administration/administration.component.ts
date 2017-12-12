import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication/authentication.service';

@Component({
  selector: 'pm-administration',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.css']
})
export class AdministrationComponent implements OnInit {
  userInRoleForm: FormGroup;
  pageTitle: string = "User Roles";
  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthenticationService) { }

  ngOnInit() {
    this.userInRoleForm = this.formBuilder.group({
      username: [''],
      role: ['']
    })

  }

  addUserToRole() {
    console.log(this.userInRoleForm.value);
    this.authService.getAllUsers()
      .subscribe(k=> console.log(k));
  }

}
