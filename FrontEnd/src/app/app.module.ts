
import {CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';

import { RouterModule } from '@angular/router';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { MoviesComponent } from './movies/movies.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { TicketBookingComponent } from './ticket-booking/ticket-booking.component';
import { BookingDisplayComponent } from './ticket-booking/booking-display/booking-display.component';
import { BookingDetailsComponent } from './ticket-booking/booking-details/booking-details.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SignInComponent,
    SignUpComponent,
    MoviesComponent,
    MovieDetailsComponent,
    HeaderComponent,
    FooterComponent,
    TicketBookingComponent,
    BookingDisplayComponent,
    BookingDetailsComponent,
   
    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path:'sign-in',component:SignInComponent},
      {path:'sign-in/sign-up', component:SignUpComponent},
      
  
      {path:'home',component:HomeComponent},
      {path:'',redirectTo:'home',pathMatch:'full' },

     {
        path: 'movies',
        component: MoviesComponent,
        children: [
          {path:'movie-details/:id',component:MovieDetailsComponent}
        ],
      },
     
      {
        path: 'ticket-booking',
        component: TicketBookingComponent,
        children: [
          {path:'booking-details/:movieId',component:BookingDetailsComponent},
        
          {path:'booking-display/:res',component:BookingDisplayComponent}
      
        ],
      }
   
     
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
