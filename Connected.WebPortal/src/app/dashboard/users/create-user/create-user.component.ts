import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { UserRegistration } from 'src/app/shared/models/user-registration.model';
import { UserService } from 'src/app/shared/services/user.service';
import { SwalComponent } from '@toverux/ngx-sweetalert2';
import { first } from 'rxjs/operators';
declare var $: any;

@Component({
  selector: 'app-create-user-modal',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  
  @ViewChild('createdUserConfirmation') private createdUserConfirmation: SwalComponent;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  userRegistration: UserRegistration = null;
  activeForm: boolean = false;

  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  addNewUserIdentity() {
    this.userService.createNewUserAccount(this.userRegistration).pipe(first()).subscribe(async () => {
      await this.createdUserConfirmation.show();
      $("#userCreate").modal("hide");
      this.modalSave.emit(null);
    })
  }

  show(): void {
    this.userRegistration = new UserRegistration();
    this.activeForm = true;
    $("#userCreate").modal("show");
  }
}
