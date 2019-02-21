import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard.component';
import { AuthRouteGuard } from '../shared/security/auth-route.guard';
import { UsersComponent } from './users/users.component';
import { PlannerComponent } from './planner/planner.component';
import { WizardComponent } from './planner/wizard/wizard.component';

const routes: Routes = [
  { 
    path: '', 
    component: DashboardComponent,
    children: [
      { path: 'home', component: HomeComponent, canActivate: [AuthRouteGuard]  },
      { path: 'users', component: UsersComponent, canActivate: [AuthRouteGuard] },
      { path: 'planner', component: PlannerComponent, canActivate: [AuthRouteGuard] }, 
      { path: 'planner/wizard', component: WizardComponent, canActivate: [AuthRouteGuard] },
      { path: '**', component: HomeComponent }
    ]
  },
  
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class DashboardRoutingModule { }
