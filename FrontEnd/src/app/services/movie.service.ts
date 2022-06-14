import { Injectable } from '@angular/core';
import { AboutMovie } from '../about-movie';

import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private baseApiUrl='https://localhost:7082'
  constructor(private httpClient:HttpClient)
   { }

getMovieId(id:number):Observable<AboutMovie>{
  console.log(id);
  return this.httpClient.get<AboutMovie>(this.baseApiUrl+'/api/Movie/getId/' +id)
}

}
