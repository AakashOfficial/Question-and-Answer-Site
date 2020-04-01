import { Component, OnInit } from '@angular/core';
import { FormsModule, FormGroup,FormControl,FormBuilder, Validators, ReactiveFormsModule} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

import {User} from 'src/app/Model/user';
import { UserService} from 'src/app/Service/user.service';
import { AuthGuard } from 'src/app/auth/auth.guard';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

// component to check all login details
export class RegisterComponent implements OnInit {
    usr = new User() ;
    form ;
    formError:boolean = false;

    constructor(private userservice : UserService, private router: Router){}

    ngOnInit() {
        this.form = new FormGroup({      
            userFirstName : new FormControl('', Validators.required),
            userLastName : new FormControl('', Validators.required),
            userEmail : new FormControl('', [Validators.required,Validators.email]),
            userPassword: new FormControl('', Validators.required),
        }) ;
    }

    get userFirstName(){
        return this.form.get('userFirstName');
    }

    get userLastName(){
        return this.form.get('userLastName');
    }

    get userEmail(){
        return this.form.get('userEmail');
    }

    get userPassword(){
        return this.form.get('userPassword');
    }

    ngOnChange() {    

    }

    Save (){
        this.usr.UserLastName = this.form.get("userLastName").value;
        this.usr.UserFirstName = this.form.get("userFirstName").value ;
        this.usr.UserEmail = this.form.get("userEmail").value;
        this.usr.UserPassword = this.form.get("userPassword").value;
        this.usr.UserActive = 1;
        this.userservice.addUser(this.usr).subscribe(
            response => {
                if(response != null){
                    this.router.navigate(['/login']);
                }else{
                    this.formError = true;
                }
            }
        );
    }
}