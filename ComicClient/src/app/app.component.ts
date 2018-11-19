import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { map } from 'rxjs/operators';
import { pipe } from 'rxjs';

import * as $ from 'jquery';
import 'foundation-sites';
import { CookieService } from 'ngx-cookie-service';
import { ComicVineSearchComponent } from './Modules/ComicVineSearch/comicVineSearch.component';
import { User } from './Models/user.model';
import { UserService } from './Services/user.services';
import { ConnectionInfo } from './Models/connectionInfo.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Collect-A-Comic';
  comicVineComponent: ComicVineSearchComponent;
  testUser: User;
  public testUsers: User[];

  // NOTE: Localhost for demo purposes only.
  // TODO: Localhost port may change. Establish designated path for demo?
  // TODO: Not a good place for the API path; just keeping here for demo purposes.
  private userService : UserService;
  private connectionInfo : ConnectionInfo = new ConnectionInfo({
    apiUrl : 'https://localhost:44324/api/',
    http: this.http
  });

  public testData: string;
  
  public ngOnInit() {
    $(document).ready(function() {
      $(document).foundation();
    });
  }

  constructor(private http: HttpClient, private cookieService: CookieService) {
    this.userService = new UserService(this.http);
  }

  // TODO: Should get the current user session via cookie if exists.
  // TODO: Planned for logging in and getting user's current collection, but ran out of time.

  connectionDemo() {
    // TODO: Leaving these here as an example of users service connection

    /* // Get One
    this.userService.getUser(this.apiUrl).subscribe(
      value => { this.testUser = value; console.log(value); console.log(this.testUser); }
    );
      

    // Get Many
    this.userService.getAllUsers(this.connectionInfo.apiUrl).subscribe(
      value => { this.testUsers = value; }
    )*/ 
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
