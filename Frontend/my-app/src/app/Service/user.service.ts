import { Injectable } from '@angular/core';
import { HttpClientModule,HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable,of ,throwError, from} from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import {User} from '../Model/user';

@Injectable({
    providedIn: 'root'
})

export class UserService {

    private baseUrl ='https://localhost:44302/api/user/';
    private completeUrl ;

    constructor(private http: HttpClient) { }

    addUser(user:User) {
        this.completeUrl = this.baseUrl + 'addUser';
        console.log("Called") ;
        return this.http.post(this.completeUrl, user) 
    }

    getUserById(id:number){
        this.completeUrl = this.baseUrl + 'getUserbyId?id=';
        return this.http.get(this.completeUrl+id) 
    }

    ValidateUser(email:string,password:string){
        this.completeUrl = this.baseUrl +"ValidateUser?email="+email+"&password="+password ;
        return this.http.get(this.completeUrl)
    }
}