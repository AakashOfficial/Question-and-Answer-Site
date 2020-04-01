
import {Component, OnInit} from '@angular/core' ;
import { ActivatedRoute, Router } from '@angular/router';

import{AnswerService} from 'src/app/Service/answer.service';
import{QuestionService} from 'src/app/Service/question.service';
import {UserReactionServie} from 'src/app/Service/userreaction.service';
import {Question} from 'src/app/Model/question';
import {Answer} from 'src/app/Model/answer';
import {UserReaction} from 'src/app/Model/userreaction';

@Component({
  selector: 'app-viewanswer',
  templateUrl: './viewanswer.component.html',
  styleUrls: ['./viewanswer.component.css']
})
export class ViewanswerComponent implements OnInit {

    userId : number = +window.sessionStorage.getItem("userId"); 
    questions = new Question();
    answers ;
    Answe ;
    jsonData :any = null ;
    constructor(private router: Router, private questionservice: QuestionService,
    private answerservice: AnswerService, private route: ActivatedRoute,
    private reactionservice: UserReactionServie){}

    ngOnInit(){
        this.questionservice.getQuestionbyID(this.route.snapshot.params['questionId']).subscribe(
            response => {
                this.questions = response as Question;
            }
        );

        this.answerservice.getAnswers(this.route.snapshot.params['questionId']).subscribe(
            response =>{
                this.answers = response;
            }
        );
    }

    getVotes(id:number,type:number) : any{
        let value :any ;
        this.reactionservice.getReactions(id,type).subscribe(
            response =>{
                value = response;
            }
        );
        return value;
    }

    onUpvote(id:number){
        let usr = new UserReaction() ;
        usr.AnswerId = id ;
        usr.ReactionType = 1 ;
        usr.UserId = +  window.sessionStorage.getItem("userId");
        this.reactionservice.addReaction(usr).subscribe(
            response => {
                if(response){
                    alert("Upvoted") ;
                }else{
                    alert("Already Reacted");
                }
            }
        );
    }

    onDevote(id:number){
        let usr = new UserReaction() ;
        usr.AnswerId = id ;
        usr.ReactionType = 0 ;
        usr.UserId = +  window.sessionStorage.getItem("userId");
        this.reactionservice.addReaction(usr).subscribe(
            response => {
                if(response){
                    alert("Devoted") ;
                }else{
                    alert("Already Reacted");
                }
            }
        );
    }

    onCheck(userid) : boolean{
        if(this.userId == userid){
            return true;
        }else{
            false;
        }
        
    }
}