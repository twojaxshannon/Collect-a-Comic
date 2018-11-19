import { Component, Input } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { map } from 'rxjs/operators';
import { pipe } from 'rxjs';
import { Issue } from '../../Models/issue.model';

@Component({
  selector: 'comicVine-issue',
  templateUrl: './comicVineIssue.component.html',
  styleUrls: ['./comicVineIssue.component.scss']
})
export class ComicVineIssueComponent {
  public _issue : Issue;

  public ngOnInit() {
  }

  @Input()
  set issue(issue: Issue) {
    this._issue = issue;
  }

  constructor(private http: HttpClient) {
  }

}