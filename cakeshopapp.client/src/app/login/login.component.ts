import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';


interface LoginCredentials {
  userName: string;
  pass: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  username: string = '';
  pass: string = '';
  result: boolean = false;

  constructor(private http: HttpClient) { }
  

  ngOnInit() {
    this.username = '';
    this.pass = '';
    console.log(this.username);
    console.log(this.pass);
  }

  redirect() {
    console.log('clicked');
    console.log(this.username);
    console.log(this.pass);
    // Call the API for login here

    const credentials: LoginCredentials = {
      userName: this.username,
      pass: this.pass
    };
    const httpOptions = {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    };

    return this.http.post<boolean>('/checklogin', JSON.stringify(credentials), httpOptions)
      .pipe(
        catchError((error) => {
          console.error('Login failed', error);
          // Return a default value if necessary
          return of(false); // or any fallback logic
        })
      )
      .subscribe(
        (result) => {
          this.result = result;
          console.log('Login success:', this.result);
        }
      );

  }
}
