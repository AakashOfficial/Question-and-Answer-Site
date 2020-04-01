import { Component, OnInit } from '@angular/core';
import {FormsModule, FormGroup,FormControl,FormBuilder, Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

import { Question} from 'src/app/Model/question';
import { QuestionService} from 'src/app/Service/question.service';
import { UserService} from 'src/app/Service/user.service';
import { AuthGuard } from 'src/app/auth/auth.guard';

@Component({
  selector: 'app-editquestion',
  templateUrl: './editquestion.component.html',
  styleUrls: ['./editquestion.component.css']
})

// component to check all login details
export class EditquestionComponent implements OnInit {

    form;
    formError: boolean = false ;
    questionSave:boolean = false ;
    question = new Question() ;

    constructor(private router: Router, private questionservice: QuestionService,
    private route: ActivatedRoute, private authguard:AuthGuard){}

    ngOnInit() {
        this.authguard.canActivate() ;
        this.questionservice.getQuestionbyID(this.route.snapshot.params['questionId']).subscribe(
            responses => {
                this.question = responses as Question;
            }
        );

        this.form = new FormGroup({      
            questionTitle : new FormControl('', Validators.required),
            questionName : new FormControl('', Validators.required),
            questionTag : new FormControl('', Validators.required),
        }) ;
    }

    get questionTitle(){
        return this.form.get('questionTitle').value;
    }
    get questionName(){
        return this.form.get('questionName').value;
    }

    get questionTag(){
        return this.form.get('questionTag').value;
    }

    updateQuestion(){
        console.log(this.question);
        if(this.question.QuestionTitle != this.form.get('questionTitle').value){
            this.question.QuestionTitle = this.form.get('questionTitle').value;
        }
        if(this.question.QuestionName != this.form.get('questionName').value){
            this.question.QuestionName = this.form.get('questionName').value;
        }
        this.question.UserId = +window.sessionStorage.getItem("userId");
        this.questionservice.UpdateQuestion(this.question).subscribe(
            response=>{
                if(response){
                    console.log(response);
                    this.questionSave = true;
                }else{
                    this.formError = true;
                }
            }
        ),(err:HttpErrorResponse)=> {
            this.formError=true;
            this.form.reset();
          };;
    }

    search(){
        this.router.navigate(['/home']);
    }

    logout() {
        window.sessionStorage.removeItem("userEmail");
        window.sessionStorage.removeItem("userId");
        this.router.navigate(['/default']);
    }

}