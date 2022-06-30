import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormControlDirective, ReactiveFormsModule, Validators } from '@angular/forms'
import { StudentsService } from '../students.service'
import { Route, Router, RouterModule, Routes } from '@angular/router'
import { TeachersService } from '../teachers.service';
import { HttpClient } from '@angular/common/http';
import {AppComponent} from '../app.component'


@Component({
  selector: 'app-login-teacher',
  templateUrl: './login-teacher.component.html',
  styleUrls: ['./login-teacher.component.css']
})
export class LoginTeacherComponent implements OnInit {

  loginValue: Boolean=false;
  TeacherLogin = new FormGroup({
    username: new FormControl('',Validators.required),
    password: new FormControl('',Validators.required)
  })
  constructor(private appComponent:AppComponent, private route: Router, private teacherService: TeachersService, private http:HttpClient) { }

  ngOnInit(): void {
  }

  CollectionOfTeachers: any;
  collectDetails() {
    // this.student.SaveDetails(this.TeacherLogin.value).subscribe((result)=>
    let Teacher = this.TeacherLogin.value;

    this.teacherService.GetList().subscribe((result) => {
      this.CollectionOfTeachers = result;

      if ((this.CollectionOfTeachers.find((e: { username: any; }) => e.username === Teacher.username))
       && (this.CollectionOfTeachers.find((e: { password: any; }) => e.password === Teacher.password)))
      {
        this.loginValue=true;
        localStorage.setItem("isUserLoggedIn", this.loginValue.toString());
        console.warn("isUserLoggedIn from login: "+localStorage.getItem("isUserLoggedIn"));        
        this.route.navigate(['/list']);
      }

      else {
        alert("Invalid Username or Password")
      }
    })
  }
}
