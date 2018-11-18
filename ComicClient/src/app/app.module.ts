import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';

import { CookieService } from 'ngx-cookie-service';
import { ComicVineSearchComponent } from './Modules/ComicVineSearch/comicVineSearch.component';

@NgModule({
  declarations: [
    AppComponent,
    ComicVineSearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule
  ],
  providers: [
    AppComponent,
    CookieService,
    ComicVineSearchComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
