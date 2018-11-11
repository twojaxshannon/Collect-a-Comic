import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { map } from 'rxjs/operators';
import { pipe } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ComicClient';

  // NOTE: Localhost for demo purposes only.
  private apiUrl = 'https://localhost:44324/api';
  public testData: string;

  constructor(private http: Http) {
    console.log("Initiating API connection test:")
    this.connectionDemo().subscribe(data => { 
      this.setTestData(data["_body"]);
    });
  }

  connectionDemo() {
    return this.http.get(`${this.apiUrl}/values/1`);
  }

  setTestData(data: any) {
    console.log(data);
    this.testData = data;
    console.log(this.testData);
  }
}
