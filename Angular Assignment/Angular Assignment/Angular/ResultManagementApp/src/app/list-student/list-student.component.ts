import { Component, OnInit } from '@angular/core';
import { StudentsService } from '../students.service';

@Component({
  selector: 'app-list-student',
  templateUrl: './list-student.component.html',
  styleUrls: ['./list-student.component.css']
})
export class ListStudentComponent implements OnInit {


  constructor(private ResultManagementApp: StudentsService) { }
  Collection: any = [];
  ngOnInit(): void {
    this.ResultManagementApp.GetList().subscribe((result) => {
      this.Collection = result
    })
  }
  DeleteStudent(id: any) {
    this.Collection.splice(id, 1);
    this.ResultManagementApp.DeleteDetails(id).subscribe();  
    

  }

}
