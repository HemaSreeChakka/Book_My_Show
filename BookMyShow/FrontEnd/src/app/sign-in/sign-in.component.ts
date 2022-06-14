import { SignInService } from './../services/sign-in.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { HttpErrorResponse } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Router } from '@angular/router';


@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent  {

constructor(private signinService :SignInService,
     private router: Router){}
 
   IsLoginError:boolean=false;
  loginForm = new FormGroup({
  
    userEmail: new FormControl('',[Validators.email,Validators.required]),
    password: new FormControl('',[Validators.required])
    
  })
   
  get userEmail() {
    return this.loginForm.get('userEmail');
  } 
  get password() {
    return this.loginForm.get('password');
  } 
  onSubmit()
  {
this.signinService.userAuthentication(this.userEmail?.value,this.password?.value).

subscribe({
  next: data => {
    localStorage.setItem('userToken',data),

    this.IsLoginError=false;
    console.log(data)
    
    this.router.navigate(['/home']);
  },
  error: HttpErrorResponse => {
    this.IsLoginError=true;
  },
 
});

    console.log(this.loginForm.value);

  }


}