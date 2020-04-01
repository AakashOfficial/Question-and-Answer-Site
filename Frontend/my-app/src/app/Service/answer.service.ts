import { Injectable } from '@angular/core';
import {HttpClientModule,HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable,of ,throwError, from} from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import {User} from 'src/app/Model/user';
import {Answer} from 'src/app/Model/Answer';
import {UserReaction} from 'src/app/Model/userreaction';
import {Question} from 'src/app/Model/question';

@Injectable({
    providedIn: 'root'
})

export class AnswerService {

    private baseUrl ='https://localhost:44302/api/answer/';
    private userreactionUrl = 'https://localhost:44302/api/userreaction/';
    private completeUrl = '' ;

    constructor(private http: HttpClient) { }

    // get all answer by the questionId
    getAnswers(QuestionID) {
        this.completeUrl = this.baseUrl + 'getAllAnswer?id=' ;
        return this.http.get(this.completeUrl+QuestionID)
    }

    //get answer on basis of answerId 
    getAnswerById(id:number) {
        this.completeUrl = this.baseUrl + 'getAnswerById?id=' + id ;
        //console.log(this.completeUrl);
        return this.http.get(this.completeUrl)
    }

    // to save the answer in backend
    AddAnswers(answer:Answer) {
        this.completeUrl = this.baseUrl + 'addAnswer' ;
        return this.http.post(this.completeUrl, answer)
    }
    
    // to update the answer
    UpdateAnswers(answer:Answer) {
        this.completeUrl = this.baseUrl + 'updateAnswer' ;
        return this.http.put(this.completeUrl, answer)
    }

    // activate answer by answerId
    activateAnswer(id:number){
        this.completeUrl = this.baseUrl + 'activateAnswer' ;
        return this.http.put(this.completeUrl, id)
    }

    // deactivate answer by answerId
    deactivateAnswer(id:number){
        this.completeUrl = this.baseUrl + 'deactivateAnswer' ;
        return this.http.put(this.completeUrl, id)
    }

    // to delete the answer by answerid
    deleteAnswer(id:number) {
        this.completeUrl = this.baseUrl + 'deleteAnswer?id' ;
        return this.http.delete(this.completeUrl+id) 
    }

    // get all answer by the questionId
    getReactions(id : number) {
        this.completeUrl = this.userreactionUrl + 'getAllReaction?id=' ;
        return this.http.get(this.completeUrl+id)
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

    // UserData with Reaction
    getAnswerVote(id:number){
        this.completeUrl = this.baseUrl + 'AnswerData?id=' ;
        return this.http.get(this.completeUrl+ id) 
    }
}