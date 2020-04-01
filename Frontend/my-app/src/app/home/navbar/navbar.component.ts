import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
//class to show navigation bar on home page
export class NavbarComponent implements OnInit {
  
  title = 'BufferOverflow';
  SignUpvalue :boolean=true;
  LoginValue:boolean=false;
  LoginPage:boolean=true;

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

   logout() {
        window.sessionStorage.removeItem("userEmail");
        window.sessionStorage.removeItem("userId");
        this.router.navigate(['/']);
    }
  
  

}
