import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { UpdateStudentComponent } from './update-student/update-student.component';
import { ListStudentComponent } from './list-student/list-student.component';
import { LoginStudentComponent } from './login-student/login-student.component';
import { LoginTeacherComponent } from './login-teacher/login-teacher.component';
import { HttpClientModule} from '@angular/common/http'
import { ReactiveFormsModule} from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { ResultComponent } from './result/result.component';
import { SearchComponent } from './search/search.component';

@NgModule({
  declarations: [
    AppComponent,
    AddStudentComponent,
    UpdateStudentComponent,
    ListStudentComponent,
    LoginStudentComponent,
    LoginTeacherComponent,
    HomeComponent,
    ResultComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
