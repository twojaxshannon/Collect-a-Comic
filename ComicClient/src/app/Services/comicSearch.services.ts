import {Injectable} from "@angular/core";
import { map } from 'rxjs/operators';
import { pipe, Observable } from 'rxjs';

import {HttpClient} from "@angular/common/http";
import { IssuesResponse } from "../Models/issuesResponse.model";
import { ComicSearch } from "../Models/comicSearch.model";

@Injectable()
export class ComicSearchService {
  constructor(private http: HttpClient) {}

  getComics(apiUrl: string, searchCriteria: ComicSearch): Observable<IssuesResponse> {
    console.log("Searching now!");
    console.log(searchCriteria);
    var criteriaAsJson = JSON.stringify(searchCriteria);
    return this.http.get<IssuesResponse>(`${apiUrl}comicvine/` + encodeURIComponent(criteriaAsJson)).pipe(
        map(res => new IssuesResponse(res)));
  }
}