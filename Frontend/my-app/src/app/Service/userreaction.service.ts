import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable,of ,throwError, from} from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import {UserReaction} from 'src/app/Model/userreaction';

@Injectable({
    providedIn: 'root'
})

export class UserReactionServie {

    private baseUrl ='https://localhost:44302/api/userreaction/';
    private completeUrl = '' ;

    constructor(private http: HttpClient) { }

    // get all answer by the questionId
    getReactions(AnswerId) {
        this.completeUrl = this.baseUrl + 'getAllReaction?id=' ;
        return this.http.get(this.completeUrl+AnswerId)
    }
    
    // add userreaction to the database
    addReaction(userreaction: UserReaction){
        this.completeUrl = this.baseUrl + 'addReaction' ;
        return this.http.post(this.completeUrl, userreaction)
    }

    // update the userreaction by the userReactionId
    updateUserReaction(id:number){
        this.completeUrl = this.baseUrl + 'updateReaction' ;
        return this.http.put(this.completeUrl, id)
    }


}