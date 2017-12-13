import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';

import { Login } from './login';
import { Router } from '@angular/router';

import {Credentials} from '../../api/credentials';

let roles = {
    "a9601694-01dc-47d4-a0d4-cd4df746c4f4": "administrator"
}

@Injectable()
export class AuthenticationService {


    constructor(private http: Http, private router: Router) { }

    registerUser(newUser: {}): Observable<Response> {
        console.log(newUser);
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Basic ${btoa(Credentials.basicAuthCredentials)}`
        });
        let options = new RequestOptions({ headers: headers });
        let url = `${Credentials.baseUrl}/user/${Credentials.appKey}`;
        return this.http.post(url, newUser, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    loginUser(user: Login): Observable<Response> {

        let url = `${Credentials.baseUrl}/user/${Credentials.appKey}/login`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Basic ${btoa(Credentials.basicAuthCredentials)}`
        });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(url, user, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    isAuthenticated() {
        if (window.localStorage.authtoken) {
            return true;
        }
        this.router.navigate(['/login']);

    }

    setIdAndRole(userInfo: any) {
        let userRole = userInfo._kmd.roles
            ? userInfo._kmd.roles[0].roleId
            : undefined;
        if (roles[userRole]) {
            window.localStorage.setItem("isAdmin", "true");
        }
        let userId = userInfo._id;
        window.localStorage.setItem("userId", userId);
    }

    getAllRoles(){
        let url = `${Credentials.baseUrl}/roles/${Credentials.appKey}`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Basic ${btoa(Credentials.masterCredentials)}`
        });
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url, options)
            .map((response: Response) => response.json())
            .catch(this.handleError)
    }

    getAllUsers(){
        let url = `${Credentials.baseUrl}/user/${Credentials.appKey}`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Kinvey ${window.localStorage.authtoken}`
        });
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url, options)
            .map((response: Response) => response.json())
            .catch(this.handleError)
    }

    isUserInRole(userId: string, role: string) {
        let roleId = '';
        for (let item in roles) {
            if (roles[item] == role) {
                roleId = item;
            }
        }
        let url = `${Credentials.baseUrl}/user/${Credentials.appKey}/${userId}`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Kinvey ${window.localStorage.authtoken}`
        });
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url, options)
            .map((response: Response) => this.userInRole(response.json(), roleId))
            .catch(this.handleError)

    }

    private userInRole(userInfo: any, roleId: string): boolean {
        let userRole = userInfo._kmd.roles
            ? userInfo._kmd.roles[0].roleId
            : undefined;
        if (!userRole) {
            return false;
        }
        if (roles[roleId]) {
         
            return true;
        }
        return false;
    }
    private handleError(error: Response): Observable<any> {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    private extractData(response: Response) {
        let body = response.json();
        return body.data || {};
    }


}