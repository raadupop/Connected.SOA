import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { SideBarComponent } from './layout/sidebar/sidebar.component';
import { HeaderComponent } from './layout/header/header.component';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';
import { FooterComponent } from './layout/footer/footer.component';
import { PageDescriptionComponent } from './layout/page-description/page-description.component';
import { UsersComponent } from './users/users.component';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import { CreateUserComponent } from './users/create-user/create-user.component';
import { EditUserComponent } from './users/edit-user/edit-user.component';
import { PlannerComponent } from './planner/planner.component';
import { WizardComponent } from './planner/wizard/wizard.component';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import { UtilsModule } from '../utils/utils.module';

@NgModule({
  declarations: [
    HomeComponent, 
    SideBarComponent,
    HeaderComponent, 
    DashboardComponent, 
    FooterComponent, 
    PageDescriptionComponent, 
    UsersComponent, 
    CreateUserComponent, 
    EditUserComponent, 
    PlannerComponent, 
    WizardComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule,
    SweetAlert2Module,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    UtilsModule
  ]
})
export class DashboardModule { }
