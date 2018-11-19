import { Component } from '@angular/core';
import { Input } from '@angular/core'
import {HttpClient} from "@angular/common/http";
import { map } from 'rxjs/operators';
import { pipe, from } from 'rxjs';
import { ComicSearchService } from '../../Services/comicSearch.services';
import { ComicSearch } from '../../Models/comicSearch.model';
import { IssueFilter } from '../../Models/issueFilter.model';
import { IssueSort } from '../../Models/issueSort.model';
import { VolumeFilter } from '../../Models/volumeFilter.model';
import { VolumeSort } from '../../Models/volumeSort.model';
import { IssuesResponse } from '../../Models/issuesResponse.model';
import { Issue } from '../../Models/issue.model';
import { ConnectionInfo } from '../../Models/connectionInfo.model';

@Component({
  selector: 'comicVine-search',
  templateUrl: './comicVineSearch.component.html',
  styleUrls: ['./comicVineSearch.component.scss']
})
export class ComicVineSearchComponent {
  private _http: HttpClient;
  private _apiUrl: string;
  private _comicService: ComicSearchService;
  public searchCriteria: ComicSearch = new ComicSearch({
    volumeFilter: new VolumeFilter(),
    volumeSort: new VolumeSort(),
    issueFilter: new IssueFilter(),
    issueSort: new IssueSort()
  });
  public searchResponse: IssuesResponse;
  

  public ngOnInit() {
  }

  @Input()
  set connectionInfo(connectionInfo: ConnectionInfo) {
    this._http = connectionInfo.http;
    this._apiUrl = connectionInfo.apiUrl;
    this._comicService = new ComicSearchService(this._http);
  }


  constructor() {
    this.searchResponse = new IssuesResponse();
    this.searchCriteria = new ComicSearch();
  }

  // TODO: Search is not returning correctly afer search fields are entered and then cleared. Debug.
  searchComics() {
    this._comicService.getComics(this._apiUrl, this.searchCriteria).subscribe(
        value => { this.searchResponse = value; console.log(value); console.log(this.searchResponse);}
      );
  }
}