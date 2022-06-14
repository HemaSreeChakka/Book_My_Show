import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AboutBooking } from '../BookingModel/about-booking';
import { AddBookingResponse } from '../BookingModel/add-booking-response';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
private baseApiUrl='https://localhost:7082';


  constructor( private httpClient:HttpClient) { }


  addBooking(BookingResponse: AboutBooking): Observable<AboutBooking> {
    const addBookingResponse: AddBookingResponse= {
ticketId:BookingResponse.ticketId,
      transactionMode: BookingResponse.transactionMode,
transactionStatus:BookingResponse.transactionStatus,
      seats: BookingResponse.seats,
totalCost:BookingResponse.totalCost,
      bookingDate: BookingResponse.bookingDate,
      
    };
  
    return this.httpClient.post<AboutBooking>(this.baseApiUrl + '/api/Ticket/add',addBookingResponse);
  }

  getBookingById(id: any): Observable<AboutBooking> {
    return this.httpClient
      .get<AboutBooking>(this.baseApiUrl + '/api/Ticket/getId/' + id );
  }



}
