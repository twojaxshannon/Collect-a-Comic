import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { CookieService } from 'ngx-cookie-service';
import { ComicVineSearchComponent } from './Modules/ComicVineSearch/comicVineSearch.component';
import { ComicVineIssueComponent } from './Modules/ComicVineIssue/comicVineIssue.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    ComicVineSearchComponent,
    ComicVineIssueComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    AppComponent,
    CookieService,
    ComicVineSearchComponent,
    ComicVineIssueComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
