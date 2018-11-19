import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { map } from 'rxjs/operators';
import { pipe } from 'rxjs';

@Component({
  selector: 'comicVine-search',
  templateUrl: './comicVineSearch.component.html',
  styleUrls: ['./comicVineSearch.component.scss']
})
export class ComicVineSearchComponent {
  // NOTE: Localhost for demo purposes only.
  // TODO: Localhost port may change. Establish designated path for demo?
  private apiUrl = 'https://localhost:44324/api/';
  public testData: string;
  public ngOnInit() {
  }

  constructor(private http: HttpClient) {
  }

  connectionDemo() {
    return this.http.get(`${this.apiUrl}values/1`);
  }
}