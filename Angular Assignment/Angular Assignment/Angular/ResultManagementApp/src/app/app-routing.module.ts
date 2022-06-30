import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddStudentComponent } from './add-student/add-student.component'
import { ListStudentComponent } from './list-student/list-student.component'
import { UpdateStudentComponent } from './update-student/update-student.component'
import { LoginStudentComponent } from './login-student/login-student.component'
import { LoginTeacherComponent } from './login-teacher/login-teacher.component'
import { HomeComponent } from './home/home.component'
import { ResultComponent} from './result/result.component'
import { SearchComponent} from './search/search.component'

const routes: Routes = [
  {
    component: HomeComponent,
    path: ""
  },
  {
    component:SearchComponent,
    path: "search"
  },
  {
    component: ResultComponent,
    path: "result/:id"
  },
  {
    component: AddStudentComponent,
    path: "add"
  },
  {
    component: ListStudentComponent,
    path: "list"
  },
  {
    component: UpdateStudentComponent,
    path: "update/:id"
  },
  {
    component: LoginStudentComponent,
    path: "studentlogin"
  },
  {
    component: LoginTeacherComponent,
    path: "teacherlogin"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
