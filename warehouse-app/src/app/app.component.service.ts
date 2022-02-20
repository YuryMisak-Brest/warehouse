import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import {Observable} from "rxjs"
import { Injectable } from '@angular/core';

@Injectable()
export class AppComponentService {

  constructor(private http: HttpClient) {
  }

  getForecast(): Observable<any[]> {
    return this.http.get<any[]>(environment.apiUrl + 'vehicles');
  }

}
