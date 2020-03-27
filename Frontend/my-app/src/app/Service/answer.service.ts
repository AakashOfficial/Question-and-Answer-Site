import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable,of ,throwError, from} from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import {User} from 'src/app/Model/user';
import {Answer} from 'src/app/Model/Answer';
import {UserReaction} from 'src/app/Model/userreaction';

@Injectable({
    providedIn: 'root'
  })

export class AnswerService {

    private productsUrl ='http://localhost:63121/api/Answer/';

    constructor(private http: HttpClient) { }
}