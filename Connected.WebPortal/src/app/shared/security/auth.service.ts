import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment'
import { map } from 'rxjs/operators';
import { AuthenticationModel } from '../models/authentication.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(authenticationModel: AuthenticationModel) {
      return this.http.post<any>(`${environment.API_URL}/authorization/authenticate`, authenticationModel)
          .pipe(map(result => {
              // login successful if there's a jwt token in the response
              if (result && result.authorizationToken) {
                  // store user details and jwt token in local storage to keep user logged in between page refreshes
                  localStorage.setItem('currentUser', JSON.stringify(result));
              }

              return result;
          }));
  }

  logout() {
      // remove user from local storage to log user out
      localStorage.removeItem('currentUser');
  }
}
