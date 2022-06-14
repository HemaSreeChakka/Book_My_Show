import { Component, OnInit } from '@angular/core';
import { NgModule }      from '@angular/core';
import { SignUpService } from '../services/sign-up.service';
import { FormBuilder, FormControl, FormGroup, MinLengthValidator, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {

  signupForm = new FormGroup({
    
    userName: new FormControl('',[Validators.required]),

    userEmail: new FormControl('',[Validators.email,Validators.required]),
userMobile: new FormControl('',[Validators.required,Validators.minLength(10),Validators.maxLength(10),Validators.pattern("^[0-9]+$")]),
    password: new FormControl('',[Validators.required]),
    confirmPassword: new FormControl('',[Validators.required])

    
  })

  constructor( private signUpService:SignUpService,

    private fb: FormBuilder,
    private router: Router
   ) { }

  

  get userName() {  return  this.signupForm.get('userName');  } 
  get password() {  return this.signupForm.get('password');   } 
  get userEmail() { return this.signupForm.get('userEmail');   } 
  get userMobile() {  return this.signupForm.get('userMobile'); } 
  get confirmPassword() {   return this.signupForm.get('confirmPassword');  } 


 
  onSubmit()
  {
 

    console.log(this.signupForm.value);

    this.signUpService.addUser(this.signupForm.value).subscribe(
      (res: any) => {
        console.log('submitted');
        console.log(res)
     alert("Successfully Registered");
     
     this.router.navigate(['/sign-in']);
      })
  }

}
