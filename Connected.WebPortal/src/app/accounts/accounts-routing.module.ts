import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AccountsComponent } from './accounts.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';

const routes: Routes = [
  { 
    path: '', 
    component: AccountsComponent,  
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'forgot-password', component: ForgotPasswordComponent}
    ]
  }
]
@NgModule({
  exports: [ RouterModule ],
  imports: [RouterModule.forChild(routes)]
})
export class AccountsRoutingModule { }
