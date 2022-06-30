import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormControlDirective } from '@angular/forms'
import { ActivatedRoute } from '@angular/router'
import { StudentsService } from '../students.service'
import { Router, RouterModule, Routes } from '@angular/router'

@Component({
  selector: 'app-update-student',
  templateUrl: './update-student.component.html',
  styleUrls: ['./update-student.component.css']
})
export class UpdateStudentComponent implements OnInit {
  EditStudent = new FormGroup({
    roll: new FormControl(''),
    name: new FormControl(''),
    dob: new FormControl(''),
    score: new FormControl(''),
  })
  Collection: any = [];
  constructor(private route: ActivatedRoute, private student: StudentsService, private router: Router) { }
  ngOnInit(): void {
    console.warn(this.route.snapshot.params['id'])
    this.student.GetDetails(this.route.snapshot.params['id'])
      .subscribe((result) => {
        this.Collection = result
        this.EditStudent = new FormGroup({
          roll: new FormControl(this.Collection['roll']),
          name: new FormControl(this.Collection['name']),
          dob: new FormControl(this.Collection['dob']),
          score: new FormControl(this.Collection['score'])
        })
      })
  }
  Update() {
    this.student.UpdateDetails(this.route.snapshot.params['id'], this.EditStudent.value)
      .subscribe((result) => console.warn(result))
    this.EditStudent.reset({});
    this.router.navigate(['/list']);
  }

}
