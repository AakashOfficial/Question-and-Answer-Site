import { Component, OnInit } from '@angular/core';
import {FormsModule, FormGroup,FormControl,FormBuilder, Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

import {User} from 'src/app/Model/user';
import { UserService} from 'src/app/Service/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

// component to check all login details
export class LoginComponent implements OnInit {

    form;
    loginFail : boolean = false;
    UserPassword:string;
    UserEmail:string;
    user = new User() ;

    constructor(private userservice : UserService, private router: Router){}

    ngOnInit() {       
       this.form = new FormGroup({
           userEmail : new FormControl('', [Validators.required,Validators.email]),
           userPassword: new FormControl('', Validators.required),
       }) ;
    }

    get userEmail(){
        return this.form.get('userEmail');
    }

    get userPassword(){
        return this.form.get('userPassword');
    }

    ngOnChange() {    

    }

    Login(){
        this.UserEmail = this.form.get("userEmail").value;
        this.UserPassword = this.form.get("userPassword").value;

        this.userservice.ValidateUser(this.UserEmail,this.UserPassword).subscribe(
            response => {
              if(response != null ){
                  console.log(response);
                  // localStorage.setItem('userId',response);
                  this.user = response as User;
                  window.sessionStorage.setItem('userId',""+this.user.UserId);
                  window.sessionStorage.setItem('userEmail', this.UserEmail);
                  this.router.navigate(['/home']);
              }else{
                this.loginFail=true;
                this.form.reset();
              } 
            }
        ),(err:HttpErrorResponse)=> {
            this.loginFail=true;
            this.form.reset();
          };

    }
    
}