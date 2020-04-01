import { Component, OnInit } from '@angular/core' ;
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-defaultnav',
  templateUrl: './defaultnav.component.html',
})
export class DefaultnavComponent implements OnInit {

    title = 'BufferOverflow';
    SignUpvalue :boolean=true;
    LoginValue:boolean=false;
    LoginPage:boolean=true;

    constructor(private router: Router){}

    ngOnInit() {
            
    }

    register():void{
        this.router.navigate(['/register']);
    }

    login() :void  { 
        this.SignUpvalue=false;
        this.LoginValue=true;
        this.LoginPage=false;
        this.router.navigate(['/login']);
    }
}