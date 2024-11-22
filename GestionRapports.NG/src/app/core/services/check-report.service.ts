
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InfoReport } from '../models/info-report';

@Injectable({
  providedIn: 'root'
})
export class CheckReportService {

  private apiUrl = 'blablabla';

  constructor(private http: HttpClient) { }


  //The function is getting all the objects "infoReport" and put them in a array
  getAllInfosReport(): Observable<InfoReport[]> {
    return this.http.get<InfoReport[]>(`${this.apiUrl}getAllInfosReport`)
  }
}
