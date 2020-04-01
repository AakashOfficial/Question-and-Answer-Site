
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
  selector: 'app-editanswer',
  templateUrl: './editanswer.component.html',
  styleUrls: ['./editanswer.component.css']
})
export class EditanswerComponent implements OnInit {

    form;
    formError: boolean = false ;
    answerSave:boolean = false ;
    queStion = new Question() ;
    answers = new Answer() ;
    answerId:number = this.route.snapshot.params['answerId'];

    constructor(private router: Router, private answerservice:AnswerService, 
    private questionservice: QuestionService,private route: ActivatedRoute, private authguard:AuthGuard){}

    ngOnInit(){
        this.authguard.canActivate() ;
        this.answerservice.getAnswerById(this.route.snapshot.params['answerId']).subscribe(
            responses => {
                this.answers = responses as Answer;
            }
        )

        this.questionservice.getQuestionbyID(this.route.snapshot.params['questionId']).subscribe(
            quest => {
                this.queStion = quest as Question;
            }
        );

        this.form = new FormGroup({      
            answerName : new FormControl('', Validators.required),
        }) ;
    }

    get answerName(){
        return this.form.get('answerName').value;
    }
    
    updateAnswer(){
        this.answers.AnswerName = this.form.get('answerName').value;

        this.answerservice.UpdateAnswers(this.answers).subscribe(
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