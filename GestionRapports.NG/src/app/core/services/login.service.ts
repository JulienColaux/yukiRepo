import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})


export class LoginService {
  private apiUrl = 'blablabla'; // changer

  constructor(private http: HttpClient) { }


  // getAllUsers(): Observable<User[]> {
  //   return this.http.get<any[]>(`${this.apiUrl}/getAllUsers`)
  // }


  //  The function constructs the URL using the provided `email` and sends a GET request to the API. 
  //  The result is an Observable that will contain the user data (if found) once the request completes.
  getUserByEmail(email: string): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}user?email=${email}`);
  }
}