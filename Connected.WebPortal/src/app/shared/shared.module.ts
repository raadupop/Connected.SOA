import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRouteGuard } from './security/auth-route.guard';
import { AuthService } from './security/auth.service';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { AlertService } from './services/alert.service';
import { UserService } from './services/user.service';
import { AlertComponent } from './directives/alert.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  declarations: [
    AlertComponent
  ],
  exports: [
    AlertComponent,
    FormsModule
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
        ngModule: SharedModule,
        providers: [
            AuthService,
            HttpClientModule,
            AuthRouteGuard,
            AlertService,
            UserService,
            { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
            { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
        ]
    }
  }
}
