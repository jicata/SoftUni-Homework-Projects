import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';

import { Login } from './login';

@Injectable()
export class AuthenticationService {
    private baseUrl: string = "https://baas.kinvey.com";
    private appKey: string = "kid_rJkenbhZf";
    private appSecret: string = "5752edceab124720ba0b10909d875b63"
    private basicAuthCredentials = `${this.appKey}:${this.appSecret}`;

    constructor(private http: Http) { }

    registerUser(newUser: {}): Observable<Response> {
        console.log(newUser);
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Basic ${btoa(this.basicAuthCredentials)}`
        });
        let options = new RequestOptions({ headers: headers });
        let url = `${this.baseUrl}/user/${this.appKey}`;
        return this.http.post(url, newUser, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    loginUser(user: Login): Observable<Response>{

        let url = `${this.baseUrl}/user/${this.appKey}/login`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Basic ${btoa(this.basicAuthCredentials)}`
        });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(url,user, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
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