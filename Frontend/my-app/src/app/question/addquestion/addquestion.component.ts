import { Component, OnInit } from '@angular/core';
import {FormsModule, FormGroup,FormControl,FormBuilder, Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

import { Question} from 'src/app/Model/question';
import { Tags} from 'src/app/Model/tags';
import { QuestionService} from 'src/app/Service/question.service';
import { UserService} from 'src/app/Service/user.service';
import { AuthGuard } from 'src/app/auth/auth.guard';

@Component({
  selector: 'app-addquestion',
  templateUrl: './addquestion.component.html',
  styleUrls: ['./addquestion.component.css']
})

// component to check all login details
export class AddquestionComponent implements OnInit {
    
    form;
    question = new Question() ;
    tags = new Tags();
    constructor(private questionservice : QuestionService, private router: Router, private authguard: AuthGuard){}

    ngOnInit() { 
        this.authguard.canActivate() ;

        this.form = new FormGroup({     
            questionTitle : new FormControl('', Validators.required), 
            questionName : new FormControl('', Validators.required),
            tagName : new FormControl('', Validators.required),

        }) ;
    }

    get questionTitle(){
        return this.form.get('questionTitle');
    }

    get questionName(){
        return this.form.get('questionName');
    }

    get tagName(){
        return this.form.get('tagName');
    }

    search(){
        this.router.navigate(['/home']);
    }

    saved(){
        if(this.form.get('questionName').value == "" || this.form.get('questionTitle').value == "" 
        || this.form.get('tagName').value == ""){
            return;
        }
        

        let questionId ;
        let tagId;
        this.question.QuestionName = this.form.get('questionName').value;
        this.question.QuestionTitle = this.form.get('questionTitle').value;
        this.question.UserId = +  window.sessionStorage.getItem("userId");
        this.question.QuestionActive = 1;
        this.tags.TagName = this.form.get('tagName').value;

        this.questionservice.saveTags(this.tags).subscribe(
             response => {
                this.question.QuestionTagId = response;
        
                this.questionservice.AddQuestion(this.question).subscribe(
                    response => {
                        if(response != ''){
                            alert("Saved");
                        }
                    }
                );
            }
        );
        // this.router.navigate(['/myquestion']);
      
    }
}