import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms' ;

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

@NgModule({
  declarations: [
    AppComponent,
    QuestionComponent,
    LoginComponent,
    RegisterComponent,
    AddquestionComponent,
    EditquestionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "login" , component : LoginComponent},
      { path: "register" , component : RegisterComponent},
      { path: "addquestion" , component : AddquestionComponent},
      { path: "editquestion" , component : EditquestionComponent},
      { path: "question" , component : QuestionComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
