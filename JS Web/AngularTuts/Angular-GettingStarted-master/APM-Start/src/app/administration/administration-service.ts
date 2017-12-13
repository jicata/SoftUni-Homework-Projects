import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';

import { Router } from '@angular/router';

import { Credentials } from '../../api/credentials';


@Injectable()
export class AdministrationService {
    constructor(private http: Http, private router: Router) { }

    getAllRoles() {
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

    addUserToRole(userId: string, roleId: string) {
        let url = `${Credentials.baseUrl}/user/${Credentials.appKey}/${userId}/roles/${roleId}`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Basic ${btoa(Credentials.masterCredentials)}`
        });

        let options = new RequestOptions({ headers: headers });
        return this.http.put(url, {}, options)
            .map((response: Response) => response.json())
            .catch(this.handleError)

    }

    private handleError(error: Response): Observable<any> {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}