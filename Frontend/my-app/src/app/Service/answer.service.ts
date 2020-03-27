import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
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
    private completeUrl = '' ;

    constructor(private http: HttpClient) { }

    // get all answer by the questionId
    getAnswers(QuestionID) {
        this.completeUrl = this.baseUrl + 'getAllAnswer?id=' ;
        return this.http.get(this.completeUrl+QuestionID)
    }

    //get answer on basis of answerId 
    getAnswerById(id:number) {
        this.completeUrl = this.baseUrl + 'getAnswerById?id=' ;
        return this.http.get(this.completeUrl+id)
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

}