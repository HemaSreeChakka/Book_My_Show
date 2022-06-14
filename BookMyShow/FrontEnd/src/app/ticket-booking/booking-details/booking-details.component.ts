import { MovieService } from 'src/app/services/movie.service';
import { BookingService } from './../../services/booking.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AboutMovie } from 'src/app/about-movie';

@Component({
  selector: 'app-booking-details',
  templateUrl: './booking-details.component.html',
  styleUrls: ['./booking-details.component.css']
})
export class BookingDetailsComponent implements OnInit {
  bookingForm!: FormGroup;
  errorMessage!: string;
  showId!: number;
  details!:AboutMovie;
  movieName!:string;
  
 count=11;
Tcost!:number;
  transactionId: any;
  constructor( private bookingService:BookingService,
    private movieService:MovieService,
    private fb: FormBuilder,
    private router: Router,
    private actRouter: ActivatedRoute) { }

  
   
  ngOnInit(): void {

    this.showId = this.actRouter.snapshot.params['movieId'];
    this.movieService.getMovieId(this.showId).subscribe((data: AboutMovie) => {
      this.details = data;
     
    });
    
    this.bookingForm = new FormGroup({
      transactionId:new FormControl(0),
      transactionMode: new FormControl(''),
      transactionStatus:new FormControl(''),
      seats:new FormControl(0),
      totalCost:new FormControl(0),
      bookingDate: new FormControl('')
     });

  }


updateCost()
{
  this.bookingForm.get('totalCost')?.setValue(this.getCost());
}

  addBookingDetails()
  {
    this.bookingService.addBooking(this.bookingForm.value).subscribe(
      (res: any) => {
        console.log('submitted');
        console.log(res)
        console.log(this.showId);
   this.router.navigate(['/ticket-booking/booking-display',res]);
      })
  }

 getCost()
 {
   console.log('keyUp');
  console.log((this.bookingForm.value.seats)*250);
 return (this.bookingForm.value.seats)*250;

  
 }

 

}
