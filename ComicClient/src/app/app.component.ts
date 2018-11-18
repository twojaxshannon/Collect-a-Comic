import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { map } from 'rxjs/operators';
import { pipe } from 'rxjs';

import * as $ from 'jquery';
import 'foundation-sites';
import { CookieService } from 'ngx-cookie-service';
import { ComicVineSearchComponent } from './Modules/ComicVineSearch/comicVineSearch.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Collect-A-Comic';
  comicVineComponent: ComicVineSearchComponent;

  // NOTE: Localhost for demo purposes only.
  // TODO: Localhost port may change. Establish designated path for demo?
  private apiUrl = 'https://localhost:44324/api/';
  public testData: string;
  public ngOnInit() {
    $(document).ready(function() {
      $(document).foundation();
    });
  }

  constructor(private http: Http, private cookieService: CookieService) {
    this.comicVineComponent =new ComicVineSearchComponent(this.http);
    console.log("Initiating API connection test:")
    /*this.connectionDemo().subscribe(data => { 
      this.setTestData(data["_body"]);
    });*/
    this.setTestData(this.connectionDemo());
  }

  // TODO: Remove any unnecessary comments, functions.

  connectionDemo() {
    return new ComicVineSearchComponent(this.http);
    //return this.http.get(`${this.apiUrl}values/1`);
  }

  setTestData(data: any) {
    console.log(data);
    this.testData = data;
    console.log(this.testData);

    this.setTestCookie(this.testData);
  }

  /* TODO: Cookie data should be tokens! Convert if time allows. */
  setTestCookie(data: any) {
    this.cookieService.set('CollectAComicTestCookie', data);
    console.log(this.cookieService.get('CollectAComicTestCookie'));
  }
}
