import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AboutMovie } from '../about-movie';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  movie!:AboutMovie;
  movies!: any[];
  genre!: string;
  searchArray!: any[];
  sortArray!: any[];
  movieFilterValue!: string;
  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  images = ['../assets/images/Gangubhai.png','../assets/images/ipl.png','../assets/images/Restaurant.png','../assets/images/MovieMunchies.png'];

  Recomended=['../assets/images/Image0.png','../assets/images/Image0.png','../assets/images/Image0.png','../assets/images/Image0.png','../assets/images/Image0.png']
  
  movieName=['Doctor Strange:In the Multiverse of madness','RRR','K.G.F. Chapter 2','Acharya','Ashoka Vanam Lo Arjuna Kalyanam']


  
  someAction(){
    console.log('HI');
    this.router.navigate(['/movies/movie-details']);
  }
}
