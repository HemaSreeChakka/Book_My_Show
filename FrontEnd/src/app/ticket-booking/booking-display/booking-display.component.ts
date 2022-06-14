import { MovieService } from './../../services/movie.service';
import { BookingService } from './../../services/booking.service';
import { Component, OnInit } from '@angular/core';
import { AboutBooking } from 'src/app/BookingModel/about-booking';
import { ActivatedRoute, Router } from '@angular/router';
import { AboutMovie } from 'src/app/about-movie';
@Component({
  selector: 'app-booking-display',
  templateUrl: './booking-display.component.html',
  styleUrls: ['./booking-display.component.css']
})
export class BookingDisplayComponent implements OnInit {booking!:AboutBooking;
bookingId!:number;
  showId: any;
details!:AboutMovie;
  constructor( private bookingService:BookingService,
    private movieService:MovieService,
    private actRouter: ActivatedRoute,
    private router: Router,) { }

  ngOnInit(): void {

    this.bookingId = this.actRouter.snapshot.params['res'];
    this.bookingService.getBookingById(this.bookingId).subscribe((data: AboutBooking) => {
      this.booking = data;
  })


}


}
