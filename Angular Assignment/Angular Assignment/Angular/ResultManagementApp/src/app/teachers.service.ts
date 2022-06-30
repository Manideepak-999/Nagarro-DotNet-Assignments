import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeachersService {
  url="http://localhost:3000/teachers"
  
  GetList()
  {
    return this.http.get(this.url);
  }

  constructor(private http: HttpClient) { }
}