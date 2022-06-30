import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms'
import { StudentsService } from '../students.service'
import { Router, RouterModule, Routes } from '@angular/router'

@Component({
  selector: 'app-login-student',
  templateUrl: './login-student.component.html',
  styleUrls: ['./login-student.component.css']
})
export class LoginStudentComponent implements OnInit {
  LoginStudent = new FormGroup({
    roll: new FormControl(''),
    dob: new FormControl(''),
  })

  constructor(private studentsService: StudentsService, private route: Router) { }
  CollectionOfStudents: any;
  ngOnInit(): void {
  }

  CollectDetails() {
    let Student = this.LoginStudent.value;console.warn("Student: ",Student);

    this.studentsService.GetList().subscribe((result) => {
      this.CollectionOfStudents = result;      
    

    if ((this.CollectionOfStudents.find((e: { roll: any; }) => e.roll === Student.roll))
      && (this.CollectionOfStudents.find((e: { dob: any; }) => e.dob === Student.dob))) {
        this.route.navigate(['/search']);
    }
    else{
      alert("User Not found")
    }

  })
  }
}
