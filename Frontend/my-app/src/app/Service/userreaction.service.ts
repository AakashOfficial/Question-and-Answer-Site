import { Injectable } from '@angular/core';
import {HttpClientModule,HttpClient,HttpHeaders} from '@angular/common/http';
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
    getReactions(AnswerId,type) {
        this.completeUrl = this.baseUrl + 'getAllReaction?id=' + AnswerId + "&type="+type ;
        return this.http.get(this.completeUrl)
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

    // delete the userreaction by the userReactionId
    deleteUserReaction(id:number){
        this.completeUrl = this.baseUrl + 'deleteReaction' ;
        return this.http.delete(this.completeUrl+id) 
    }
}