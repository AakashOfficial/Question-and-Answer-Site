import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable,of ,throwError, from} from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import {User} from 'src/app/Model/user';
import {Question} from  'src/app/Model/question';
import {Tags} from 'src/app/Model/Tags';

export class QuestionService {
    private questionBaseUrl ;

    constructor(private http: HttpClient) { }

    getQuestions(){   
      this.questionBaseUrl = 'https://localhost:44302/api/question/getAllQuestion';
        return this.http.get(this.questionBaseUrl)
    }

    // get question by questionId
    getQuestionbyID(id:number) {   
      this.questionBaseUrl = 'https://localhost:44302/api/question/getQuestionById';
        return this.http.get(this.questionBaseUrl+id)
    }

    // add question to the database
    AddQuestion(question:Question,tag:Tags) {
        this.questionBaseUrl = 'https://localhost:44302/api/question/AddQuestion';
        return this.http.post(this.questionBaseUrl, {question,tag}) 
    }

    // update the question
    UpdateQuestion(question:Question,tag:Tags) {
        this.questionBaseUrl = 'https://localhost:44302/api/question/updateQuestion';
        return this.http.put(this.questionBaseUrl, {question,tag}) 
    }

    // activate the question by questionId
    activeQuestion(id:number){
        this.questionBaseUrl = 'https://localhost:44302/api/question/activateQuestion';
        return this.http.put(this.questionBaseUrl,{id})
    }

    // deactivate the question by questionId
    deactiveQuestion(id:number){
        this.questionBaseUrl = 'https://localhost:44302/api/question/deactivateQuestion';
        return this.http.put(this.questionBaseUrl,{id})
    }

    // delete the question by questionId
    deleteQuestion(id:number) {
        this.questionBaseUrl = 'https://localhost:44302/api/question/deleteQuestion';
        return this.http.delete(this.questionBaseUrl+id) 
    }
}