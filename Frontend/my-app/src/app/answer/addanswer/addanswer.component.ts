
import {Component, OnInit} from '@angular/core' ;
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule, FormGroup,FormControl,FormBuilder, Validators, ReactiveFormsModule} from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

import {AnswerService} from 'src/app/Service/answer.service';
import {QuestionService} from 'src/app/Service/question.service';
import { AuthGuard } from 'src/app/auth/auth.guard';
import {Question} from 'src/app/Model/question';
import {Answer} from 'src/app/Model/answer';

@Component({
  selector: 'app-addanswer',
  templateUrl: './addanswer.component.html',
  styleUrls: ['./addanswer.component.css']
})
export class AddanswerComponent implements OnInit {
    
    form;
    formError: boolean = false ;
    answerSave:boolean = false ;
    question = new Question() ;
    answer = new Answer() ;
    questionId:number = this.route.snapshot.params['questionId'];

    constructor(private router: Router, private answerservice:AnswerService, 
    private questionservice: QuestionService,private route: ActivatedRoute, private authguard:AuthGuard){}

    ngOnInit(){
        this.authguard.canActivate() ;
        this.questionservice.getQuestionbyID(this.questionId).subscribe(
            response => {
                this.question = response as Question;
                console.log(this.question);
            }
        );

        this.form = new FormGroup({      
            answerName : new FormControl('', Validators.required),
        }) ;
    }

    get answerName(){
        return this.form.get('answerName').value;
    }

    saveAnswer(){
        this.answer.AnswerName = this.form.get('answerName').value;
        this.answer.AnswerActive = 1;
        this.answer.QuestionId = this.questionId ;
        this.answer.UserId = +  window.sessionStorage.getItem("userId");

        this.answerservice.AddAnswers(this.answer).subscribe(
            response=>{
                if(response != null){
                    this.answerSave = true;
                }else{
                    this.formError = true;
                }
            }
        ),(err:HttpErrorResponse)=> {
            this.formError=true;
            this.form.reset();
          };;
    }
}