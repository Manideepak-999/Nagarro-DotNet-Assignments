import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormControlDirective,ReactiveFormsModule } from '@angular/forms'
import { StudentsService } from '../students.service'

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnInit {

  AddStudent = new FormGroup({
    roll: new FormControl(''),
    name: new FormControl(''),
    dob: new FormControl(''),
    score: new FormControl(''),
  })
  constructor(private student: StudentsService) { }

  ngOnInit(): void {
  }
  CollectDetails() {
    this.student.SaveDetails(this.AddStudent.value).subscribe((result) =>
      console.warn("the results are here", result));
    this.AddStudent.reset({});
  }
}
