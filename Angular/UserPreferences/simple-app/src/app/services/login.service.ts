import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

import { UserDto } from '../interfaces/UserDto';

const endpoint = 'https://localhost:5001/api/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Cache-Control': 'no-cache',
    'Access-Control-Allow-Origin': 'http://localhost:4800'
  })
};

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) {
  }

  loginIntoApplication(userData: UserDto): Observable<UserDto> {
    console.log(`Received Request: ${userData.userNickName}`);

    return this.httpClient.post<UserDto>(endpoint + 'userpreferences', JSON.stringify(userData), httpOptions).pipe(
      tap((user) => console.log(`added User w/ id=${user.userNickName}`)),
      catchError(this.handleError<any>('addUser'))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}

