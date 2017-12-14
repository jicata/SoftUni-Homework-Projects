import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import { IProduct } from "./product";
import { HttpErrorResponse } from "@angular/common/http/src/response";
import { Credentials } from "../../api/credentials";

@Injectable()
export class ProductService {

    constructor(private http: Http) {

    }

    updateProduct(product: IProduct){
        let url = `${Credentials.baseUrl}/appdata/${Credentials.appKey}/products/${product._id}`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Kinvey ${window.localStorage.getItem('authtoken')}`
        });
        let options = new RequestOptions({ headers: headers });
    
        return this.http.put(url,product, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    getProduct(id:string): Observable<IProduct>{
        let url = `${Credentials.baseUrl}/appdata/${Credentials.appKey}/products/${id}`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Kinvey ${window.localStorage.getItem('authtoken')}`
        });
        let options = new RequestOptions({ headers: headers });
    
        return this.http.get(url,options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    getProducts(): Observable<IProduct[]> {
        let url = `${Credentials.baseUrl}/appdata/${Credentials.appKey}/products`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Basic ${btoa(Credentials.masterCredentials)}`
        });
        let options = new RequestOptions({ headers: headers });
    
        return this.http.get(url,options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    createProduct(product: IProduct): Observable<Response>{
        let url = `${Credentials.baseUrl}/appdata/${Credentials.appKey}/products`;
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Authorization': `Basic ${btoa(Credentials.masterCredentials)}`
        });
        let options = new RequestOptions({ headers: headers });
    
        return this.http.post(url,product, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
    }
}