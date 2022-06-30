import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms'
import { StudentsService } from '../students.service'
import { Router, RouterModule, Routes } from '@angular/router'

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  StudentSearch = new FormGroup({
    roll: new FormControl(''),
    name: new FormControl(''),
  })

  constructor(private studentsService: StudentsService, private route: Router) { }
  CollectionOfStudents: any;
  ngOnInit(): void {
  }

  CollectDetails() {
    let Student = this.StudentSearch.value;console.warn("Student: ",Student);

    this.studentsService.GetList().subscribe((result) => {
      this.CollectionOfStudents = result;      
    

    if ((this.CollectionOfStudents.find((e: { roll: any; }) => e.roll === Student.roll))
      && (this.CollectionOfStudents.find((e: { name: any; }) => e.name === Student.name))) {
        this.route.navigate([`/result/${Student.roll}`]);
    }
    else{
      alert("User Not found")
    }

  })
  }
}
