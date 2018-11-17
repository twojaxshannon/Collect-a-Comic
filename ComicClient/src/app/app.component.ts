import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { map } from 'rxjs/operators';
import { pipe } from 'rxjs';

import * as $ from 'jquery';
import 'foundation-sites';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ComicClient';

  // NOTE: Localhost for demo purposes only.
  private apiUrl = 'https://localhost:44350/api/';
  public testData: string;
  public ngOnInit() {
    $(document).ready(function() {
      $(document).foundation();
    });
  }

  constructor(private http: Http, private cookieService: CookieService) {
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

    this.setTestCookie(this.testData);
  }

  setTestCookie(data: any) {
    this.cookieService.set('CollectAComicTestCookie', data);
    console.log(this.cookieService.get('CollectAComicTestCookie'));
  }
}
