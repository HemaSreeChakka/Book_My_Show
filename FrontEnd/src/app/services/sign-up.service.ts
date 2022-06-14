import { AboutSignUp } from './../signUpmodel/about-sign-up';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddSignUpResponse } from '../signUpmodel/add-sign-up-response';
@Injectable({
  providedIn: 'root'
})
export class SignUpService {

  private baseApiUrl='https://localhost:7082';


  constructor( private httpClient:HttpClient) { }


  addUser(SignUpResponse: AboutSignUp): Observable<AboutSignUp> {
    const addSignUpResponse: AddSignUpResponse= {
      userName:SignUpResponse.userName,
      userEmail:SignUpResponse.userEmail,
      userMobile:SignUpResponse.userMobile,
      password:SignUpResponse.password,
      confirmPassword:SignUpResponse.confirmPassword
    };
  
    return this.httpClient.post<AboutSignUp>(this.baseApiUrl + '/api/Contact/add',addSignUpResponse);
  }
}
