import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

// AuthGuard Class prevent the Pages from Unauthenticated and Unauthorized User
export class AuthGuard implements CanActivate {
  
    constructor( private router: ActivatedRoute, private route: Router) { }

    // Function for prevent the Pages from Unauthenticated and Unauthorized User
    canActivate(): boolean {
        // Unauthenticated and Unauthorized User show this Message while accessing page by the URL
        if (window.sessionStorage.getItem('userEmail') === null ) {
            window.alert("You don't have the Valid Credentials to Access this Page. Please Login First");
            window.sessionStorage.clear();
            this.route.navigate(['/login']);
            return false;
        } else {
            return true;
        }
    }  
}