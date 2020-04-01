import { ActivatedRoute, Router, Route } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Question} from 'src/app/Model/question';
import { QuestionService } from 'src/app/Service/question.service';
import{ User } from 'src/app/Model/user';
import{ UserService } from 'src/app/Service/user.service';
import {Tags} from 'src/app/Model/tags';
import {FormsModule, FormGroup,FormControl,FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.css']
})
export class DefaultComponent implements OnInit {
    questions :any ;
    user : any;
    form ;
    title = 'BufferOverflow';
    SignUpvalue :boolean=true;
    LoginValue:boolean=false;
    LoginPage:boolean=true;

     constructor(private questionService: QuestionService,private userservce :UserService,private router: Router) { }

   refreshForm() {
        this.questionService.getQuestions().subscribe(
        questions => {
            this.questions = questions;
        });
    }

    ngOnInit() {
        this.refreshForm();
        this.form = new FormGroup({
           searched : new FormControl('', Validators.required),
       }) ;
    }

    get searched(){
        return this.form.get('searched');
    }
    search(){
        let searchedValue = this.searched.value;
        this.questionService.Search(searchedValue).subscribe(
            questions => {
            this.questions = questions;
        });
    }

    LoginClick() :void  { 
        this.SignUpvalue=false;
        this.LoginValue=true;
        this.LoginPage=false;
        this.router.navigate(['/login']);
    }
}