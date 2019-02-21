import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountsComponent } from './accounts.component';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { AccountsRoutingModule } from './accounts-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    AccountsComponent, 
    LayoutComponent, 
    LoginComponent, 
    RegisterComponent, 
    ForgotPasswordComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AccountsRoutingModule,
    SharedModule
  ]
})
export class AccountsModule { }
