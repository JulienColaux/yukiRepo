import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import {UserLogin} from '../models/userLogin';

@Injectable({
  providedIn: 'root'
})


export class LoginService {
  private apiUrl = 'https://localhost:44312/api/User/login'; // changer
  private token: string | null = null;

  constructor(private http: HttpClient) { }


  // getAllUsers(): Observable<User[]> {
  //   return this.http.get<any[]>(`${this.apiUrl}/getAllUsers`)
  // }


  //  The function constructs the URL using the provided `email` and sends a GET request to the API.
  //  The result is an Observable that will contain the user data (if found) once the request completes.
  getUserByEmail(email: string): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}user?email=${email}`);
  }

  login(userData : UserLogin): Observable<any> {
    return this.http.post<any>(this.apiUrl, userData);
  }

  setToken(token: string): void {
    localStorage.setItem('auth_token', token);
    this.token = token;
  }

  // Fonction pour obtenir le token stocké
  getToken(): string | null {
    if (!this.token) {
      this.token = localStorage.getItem('auth_token');
    }
    return this.token;
  }

  // Fonction pour se déconnecter
  logout(): void {
    localStorage.removeItem('auth_token');
    this.token = null;
  }

  // Fonction pour vérifier si l'utilisateur est connecté
  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }

  // Ajouter le token dans les en-têtes HTTP
  addAuthHeader(headers: HttpHeaders): HttpHeaders {
    const token = this.getToken();
    if (token) {
      return headers.set('Authorization', `Bearer ${token}`);
    }
    return headers;
  }
}
