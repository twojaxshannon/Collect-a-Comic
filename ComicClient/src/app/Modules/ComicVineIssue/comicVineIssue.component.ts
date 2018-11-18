import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { map } from 'rxjs/operators';
import { pipe } from 'rxjs';

@Component({
  selector: 'comicVine-issue',
  templateUrl: './comicVineIssue.component.html',
  styleUrls: ['./comicVineIssue.component.scss']
})
export class ComicVineIssueComponent {
  // NOTE: Localhost for demo purposes only.
  // TODO: Localhost port may change. Establish designated path for demo?
  private apiUrl = 'https://localhost:44324/api/';
  public testData: string;
  public ngOnInit() {
    /*$(document).ready(function() {
      $(document).foundation();
    }); */
  }

  constructor(private http: Http) {
    console.log("In the Issues component!");
    /* TODO: REmove subscribe test while testing UI
    this.connectionDemo().subscribe(data => { 
        console.log(data["_body"]);
      }); */
    console.log("I logged a thing.");
  }

  connectionDemo() {
    return this.http.get(`${this.apiUrl}values/1`);
  }
}