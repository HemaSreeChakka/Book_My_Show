import { SignInService } from './../../services/sign-in.service';

import { Component, OnInit } from '@angular/core';
import { AboutMovie } from 'src/app/about-movie';
import { MovieService } from 'src/app/services/movie.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  details!:AboutMovie;
  movieId!: number;
  authenticated: boolean=false;
  constructor( private movieService:MovieService,
    private actRouter: ActivatedRoute,
    private signinService:SignInService
    ) { }
  



  ngOnInit(): void {

    this.authenticated=this.signinService.IsLoggedIn;
  

    this.movieId = this.actRouter.snapshot.params['id'];
    console.log(this.movieId);
    this.movieService.getMovieId(this.movieId).subscribe((data: AboutMovie) => {
      this.details = data;
     
    });



   
  }
book()
{
  this.authenticated=!this.authenticated;
}
}
