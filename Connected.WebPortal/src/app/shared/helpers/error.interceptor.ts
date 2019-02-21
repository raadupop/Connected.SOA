import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from 'rxjs/operators';
import { AuthService } from '../security/auth.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    
    constructor(private authenticationService: AuthService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
       return next.handle(request).pipe(catchError(err => {
           if (err.status === 401) {
               // logout if 401 response returned from api
               this.authenticationService.logout();
               location.reload(true)
           } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(
              `Backend returned code ${err.status}, ` +
              `body was: ${err.error}`);
          }

           const error =  'Something bad happened; please try again later.';
           return throwError(error);
       }))
    }
}