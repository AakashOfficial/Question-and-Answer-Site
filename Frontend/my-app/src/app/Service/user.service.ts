import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable,of ,throwError, from} from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import {User} from '../Model/user';

@Injectable({
    providedIn: 'root'
})

export class RegisterService {

    private productsUrl  ;

    constructor(private http: HttpClient) { }

    
}