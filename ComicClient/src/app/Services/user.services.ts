import {Injectable} from "@angular/core";
import { map } from 'rxjs/operators';
import { pipe, Observable } from 'rxjs';
import { User } from "../Models/user.model";

import {HttpClient} from "@angular/common/http";

@Injectable()
export class UserService {
  constructor(private http: HttpClient) {}

  getUser(apiUrl: string): Observable<User> {
      return this.http.get<User>(`${apiUrl}values/1`).pipe(
        map(res => new User(res)));
  }

  getAllUsers(apiUrl: string): Observable<User[]> {
    return this.http.get<User[]>(`${apiUrl}values/1`).pipe(
        map(res => (<User[]>res)));
  }
}