import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { UserAccount } from 'src/app/shared/models/user-account.model';
import { UserService } from 'src/app/shared/services/user.service';
import { first } from 'rxjs/operators';
import { SwalComponent } from '@toverux/ngx-sweetalert2';

declare var $: any;

@Component({
  selector: 'app-edit-user-modal',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  @ViewChild("editUserConfirmation") editUserConfirmation: SwalComponent;
  @Output() saveModal: EventEmitter<any> = new EventEmitter<any>();

  activeForm: boolean = false;
  userAccount: UserAccount = null;

  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  updateUserAccountInformation(){
    this.userService.updateUserIdentity(this.userAccount).pipe(first()).subscribe(async () => {
      await this.editUserConfirmation.show();
      $("#userEdit").modal("hide");
      this.saveModal.emit(null);
    });
  }

  show(user: UserAccount){
    this.userAccount = user;
    this.activeForm = true;
    $("#userEdit").modal("show");
  }
}
