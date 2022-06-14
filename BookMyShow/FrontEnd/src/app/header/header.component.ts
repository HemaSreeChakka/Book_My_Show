import { SignInService } from './../services/sign-in.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  authenticated: boolean=false;

  constructor(private signinService:SignInService) { }

  ngOnInit(): void {
    this.authenticated=this.signinService.IsLoggedIn;

  }
signOut()
{
  this.authenticated=!this.authenticated;
}
}
