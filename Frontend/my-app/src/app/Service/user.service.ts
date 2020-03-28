import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable,of ,throwError, from} from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import {User} from '../Model/user';

@Injectable({
    providedIn: 'root'
})

export class RegisterService {

    private baseUrl ='https://localhost:44302/api/user/';
    private completeUrl ;

    constructor(private http: HttpClient) { }

    createProduct(user:User) {
        this.completeUrl = this.baseUrl + '';
        return this.http.post(this.completeUrl, user) 
    }
}