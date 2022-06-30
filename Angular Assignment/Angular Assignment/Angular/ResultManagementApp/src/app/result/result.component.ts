import { Component, OnInit } from '@angular/core';
import {StudentsService } from '../students.service'
import { Router, RouterModule, Routes } from '@angular/router'

import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {
  constructor(private ResultManagementApp: StudentsService, private route: ActivatedRoute) { }
  Collection: any = [];
  ngOnInit(): void {
    this.ResultManagementApp.GetDetails(this.route.snapshot.params['id']).subscribe((result) => {
      this.Collection = result
    })
  }
  

  

}
