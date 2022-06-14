import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class SignInService {
  IsLoggedIn=false;
private baseUrl='https://localhost:7082';
  constructor(private httpClient:HttpClient) { }



  userAuthentication(userEmail:any,password:any):Observable<any>
  {

    this.IsLoggedIn=true;
    console.log(this.IsLoggedIn);
return this.httpClient.post(this.baseUrl+'/api/Token/Authenticate',{userEmail,password},{responseType: 'text'});



   
  }



}
