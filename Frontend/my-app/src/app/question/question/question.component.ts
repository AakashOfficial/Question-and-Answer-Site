import { Component, OnInit } from '@angular/core';
import { Question} from 'src/app/Model/question';
import { QuestionService } from 'src/app/Service/question.service';
import{ User } from 'src/app/Model/user';
import{ UserService } from 'src/app/Service/user.service';
import {Tags} from 'src/app/Model/tags';
import {FormsModule, FormGroup,FormControl,FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})

export class QuestionComponent implements OnInit {
    questions :any ;
    user : any;
    form;
     p: number = 1;
    searchTerm:string;
    _listFilter:string;
    register: Question[]=[];
    tag:Tags;
    errorMessage: any;
    userID:number = +window.sessionStorage.getItem("userId");

    // filter of search
    filteredProducts:Question[];
  
    constructor(private questionService: QuestionService,private userservce :UserService) { }

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

    ngOnChange()  {    
        this.refreshForm();
    }
  
    get searched(){
        return this.form.get('searched');
    }
    check(userid): boolean{
        if(this.userID == userid){
            return true;
        }else{
            return false;
        }
    }

    search(){
        let searchedValue = this.searched.value;
        this.questionService.Search(searchedValue).subscribe(
            questions => {
            this.questions = questions;
        });
    }
}