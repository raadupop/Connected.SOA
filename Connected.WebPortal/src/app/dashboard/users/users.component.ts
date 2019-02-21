import { Component, OnInit, ViewChild } from '@angular/core';
import { UserAccountGrid } from 'src/app/shared/models/user-grid.model';
import { UserService } from 'src/app/shared/services/user.service';
import { first } from 'rxjs/operators';
import { SwalComponent } from '@toverux/ngx-sweetalert2';
import { CreateUserComponent } from './create-user/create-user.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { UserAccount } from 'src/app/shared/models/user-account.model';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  @ViewChild('deletedUserConfirmation') private deletedUserConfirmation: SwalComponent;
  @ViewChild('createUserModal') private createUserModal: CreateUserComponent;
  @ViewChild('editUserModal') private editUserModal: EditUserComponent;

  usersGrid: UserAccountGrid;

  constructor(private userService: UserService) {
  }
  
  ngOnInit(): void {
    this.loadAllUsers();
  }

  deleteUser(userId: number) {
    this.userService.deleteUserIdentity(userId).pipe(first()).subscribe(async () => {
      await this.deletedUserConfirmation.show();
      await this.loadAllUsers();
    });
  }

  private loadAllUsers() {
    this.userService.getAllUserAccounts().pipe(first()).subscribe(userGridResult => {
        this.usersGrid = userGridResult;
    })
  }

  createUser(): void {
    this.createUserModal.show();
  }

  editUser(user: UserAccount): void {
    this.editUserModal.show(user);
  }
}
