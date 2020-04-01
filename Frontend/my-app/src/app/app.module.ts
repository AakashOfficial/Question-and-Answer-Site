import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms' ;
import {NgxPaginationModule} from 'ngx-pagination'; 
import {Ng2SearchPipeModule} from 'ng2-search-filter'; 

import {RouterModule} from '@angular/router';
import {HttpClientModule,HttpClient,HttpHeaders} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
// import { FooterComponent } from './footer/footer.component';
import { QuestionComponent } from './question/question/question.component';
import {LoginComponent} from './user/login/login.component';
import {RegisterComponent} from './user/register/register.component';
import { AddquestionComponent } from './question/addquestion/addquestion.component' ;
import { EditquestionComponent } from './question/editquestion/editquestion.component' ;
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './home/navbar/navbar.component';
import { DefaultComponent } from './default/default.component';
import { DefaultnavComponent } from './default/defaultnav/defaultnav.component';
import { MyquestionComponent } from './question/myquestion/myquestion.component';
import { ViewanswerComponent } from './answer/viewanswer/viewanswer.component';
import { EditanswerComponent } from './answer/editanswer/editanswer.component';
import { AddanswerComponent } from './answer/addanswer/addanswer.component';

@NgModule({
  declarations: [
    AppComponent,
    QuestionComponent,
    LoginComponent,
    RegisterComponent,
    AddquestionComponent,
    EditquestionComponent,
    HomeComponent,
    NavbarComponent,
    DefaultComponent,
    DefaultnavComponent,
    MyquestionComponent,
    ViewanswerComponent,
    EditanswerComponent,
    AddanswerComponent,
  ],
  imports: [
    Ng2SearchPipeModule,
    NgxPaginationModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "" , component : DefaultComponent},
      { path: "default" , component : DefaultComponent},
      { path: "myquestion" , component : MyquestionComponent},
      { path: "home" , component : HomeComponent},
      { path: "login" , component : LoginComponent},
      { path: "register" , component : RegisterComponent},
      { path: "addquestion" , component : AddquestionComponent},
      { path: "editquestion" , component : EditquestionComponent},
      { path: "question" , component : QuestionComponent},
      { path: "viewanswer/:questionId" , component : ViewanswerComponent},
      { path: "editanswer/:questionId/:answerId" , component : EditanswerComponent},
      { path: "addanswer/:questionId" , component : AddanswerComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
