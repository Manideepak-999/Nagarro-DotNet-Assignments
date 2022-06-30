import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  url="http://localhost:3000/students"
  
  GetList()
  {
    return this.http.get(this.url);
  }
  SaveDetails(data={})
  {
    return this.http.post(this.url,data)
  }
  DeleteDetails(id:any){
    return this.http.delete(`${this.url}/${id}`);
  }
  GetDetails(id:any){
    return this.http.get(`${this.url}/${id}`);
  }
  UpdateDetails(id:any,data:any){
    return this.http.put(`${this.url}/${id}`,data);
  }

  constructor(private http: HttpClient) { }
}
