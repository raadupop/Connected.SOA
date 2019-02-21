import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from "@angular/router";

import { first } from "rxjs/operators";
import { AuthService } from '../../shared/security/auth.service';
import { AlertService } from '../../shared/services/alert.service';
import { AuthenticationModel } from 'src/app/shared/models/authentication.model';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    authenticationModel: AuthenticationModel = { email: '', password: '' };
    loading = false;
    submitted = false;
    returnUrl: string;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthService,
        private alertService: AlertService
    ) { }

    ngOnInit(): void {
        this.authenticationService.logout();
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    onSubmit() {
        this.submitted = true;

        this.loading = true;
        this.authenticationService.login(this.authenticationModel)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate([this.returnUrl])
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
}
