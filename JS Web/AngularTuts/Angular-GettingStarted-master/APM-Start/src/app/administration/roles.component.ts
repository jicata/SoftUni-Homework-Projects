import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication/authentication.service';
import { AdministrationService } from './administration-service';

@Component({
  selector: 'pm-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./administration.component.css']
})
export class RolesComponent implements OnInit {
  userInRoleForm: FormGroup;
  pageTitle: string = "User Roles";
  users: [{}] = [{}];
  roles: [{}] = [{}];
  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthenticationService,
  private adminService: AdministrationService) { }

  ngOnInit() {
    this.userInRoleForm = this.formBuilder.group({
      userId: [''],
      role: ['']
    })

    this.authService.getAllUsers()
    .subscribe(data=> {
      this.users = data;
    });

    this.adminService.getAllRoles()
      .subscribe(data =>{
        this.roles = data;
      })
  }

  addUserToRole() {
    let formValues = this.userInRoleForm.value;
    let roleId = formValues.role;
    let userId = formValues.userId;
    this.adminService.addUserToRole(userId, roleId)
      .subscribe(data => {
        console.log(data);
        this.router.navigate(['/administration']);
      })
    
  }

}
