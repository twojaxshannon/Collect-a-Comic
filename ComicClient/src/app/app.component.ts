import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { map } from 'rxjs/operators';
import { pipe } from 'rxjs';

import * as $ from 'jquery';
import 'foundation-sites';
import { CookieService } from 'ngx-cookie-service';
import { ComicVineSearchComponent } from './Modules/ComicVineSearch/comicVineSearch.component';
import { userInfo } from 'os';
import { User } from './Models/user.model';
import { UserService } from './Services/user.services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Collect-A-Comic';
  comicVineComponent: ComicVineSearchComponent;
  testUser: User;
  testUsers: User[];

  // NOTE: Localhost for demo purposes only.
  // TODO: Localhost port may change. Establish designated path for demo?
  private apiUrl = 'https://localhost:44324/api/';
  private userService : UserService;
  public testData: string;
  
  public ngOnInit() {
    $(document).ready(function() {
      $(document).foundation();
    });
  }

  constructor(private http: HttpClient, private cookieService: CookieService) {
    this.userService = new UserService(this.http);
    this.comicVineComponent =new ComicVineSearchComponent(this.http);
    console.log(this.connectionDemo());
  }

  // TODO: Remove any unnecessary comments, functions.

  connectionDemo() {
    /* // Get One
    this.userService.getUser(this.apiUrl).subscribe(
      value => { this.testUser = value; console.log(value); console.log(this.testUser); }
    );
      */ 

    // Get Many
    this.userService.getAllUsers(this.apiUrl).subscribe(
      value => {console.log(value); this.testUsers = value; console.log(this.testUsers);}
    )
    return this.testUser;
    
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
