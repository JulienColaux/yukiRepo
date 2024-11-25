import { Injectable } from '@angular/core'; 
import { Observable } from 'rxjs'; 
import { HttpClient } from '@angular/common/http'; 

@Injectable({
  providedIn: 'root' 
})
export class AddUserService {
  private apiUrl = 'blablabla'; 

  
  constructor(private http: HttpClient) { }

  // Method to send user data to the API using a POST request
  addUser(userData: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, userData); 
  }
}

