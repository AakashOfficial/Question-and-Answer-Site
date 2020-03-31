import { Injectable } from '@angular/core';
import {HttpClientModule,HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable,of ,throwError, from} from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import {User} from 'src/app/Model/user';
import {Question} from  'src/app/Model/question';
import {Tags} from 'src/app/Model/Tags';

@Injectable({
    providedIn: 'root'
})

export class QuestionService {
    private baseUrl ='https://localhost:44302/api/question/';
    private completeUrl = '' ;

    constructor(private http: HttpClient) { }

    getQuestions(){   
        this.completeUrl = this.baseUrl + 'getAllQuestion';
        // console.log(this.completeUrl);
        return this.http.get(this.completeUrl)
    }

    // get question by questionId
    getQuestionbyID(id:number) {   
      this.completeUrl = this.baseUrl + 'getQuestionById?id=';
        return this.http.get(this.completeUrl+id)
    }

    // add question to the database
    AddQuestion(question:Question,tag:Tags) {
        this.completeUrl = this.baseUrl + 'AddQuestion';
        return this.http.post(this.completeUrl, {question,tag}) 
    }

    // update the question
    UpdateQuestion(question:Question,tag:Tags) {
        this.completeUrl = this.baseUrl + 'updateQuestion';
        return this.http.put(this.completeUrl, {question,tag}) 
    }

    // activate the question by questionId
    activeQuestion(id:number){
        this.completeUrl = this.baseUrl + 'activateQuestion';
        return this.http.put(this.completeUrl,id)
    }

    // deactivate the question by questionId
    deactiveQuestion(id:number){
        this.completeUrl = this.baseUrl + 'deactivateQuestion';
        return this.http.put(this.completeUrl,id)
    }

    // delete the question by questionId
    deleteQuestion(id:number) {
        this.completeUrl = this.baseUrl + 'deleteQuestion?id=';
        return this.http.delete(this.completeUrl+id) 
    }
}