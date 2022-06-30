import { Component } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ResultManagementApp';
  loginValue: Boolean = false;

  isLoggedIn(): any {
    localStorage.setItem("isUserLoggedIn", this.loginValue.toString())
    console.warn(localStorage.getItem("isUserLoggedIn"));
    return localStorage.getItem("isUserLoggedIn");
  }
}