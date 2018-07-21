import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { BaseComponent } from '../shared/base-component';
import { ChangePassword } from '../models/domain/user-entities';
import { TabsModule } from 'ngx-bootstrap/tabs';

import { LookupConstants, LookupDetailConstants } from '../models/utilities/lookup-constants';
import { PayCycle } from '../models/payroll/PayCycle-entities';
import { ApprisalYear } from '../models/payroll/apprisalyear-entities';
import { LookUpDetail } from '../models/domain/lookup-entities';

import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';

@Component({
    templateUrl: './forgot.component.html',
    providers: []
})
export class ForgotPasswordComponent extends BaseComponent implements OnInit {


    /* Pay Cycle Setting Variables */
    public payCycleFormGroup: FormGroup;
    public ApprisalYearList: ApprisalYear[];
    public lookupPayCycleList: LookUpDetail[];
    public lookupCalculateModeList: LookUpDetail[];
    public payCycle: PayCycle;
    public payCycleList: Array<LookUpDetail>;
    public payCalculationModeList: Array<LookUpDetail>;
    public IsStartDate: boolean = false;
    /* Change Password Variables */
    public changePassword: ChangePassword[];
    public changePasswordFormGroup: FormGroup;
    public selectedChangePassword: ChangePassword;
    public userid: number;
    public routeUrl: string;
    public router: Router;

    ngOnInit() {
        this.route.params.subscribe(params => {
            if (params['id'] != null) {
                this.userid = Number.parseInt(params['id']);
            }
        });
        this.selectedChangePassword = new ChangePassword();
        this.selectedChangePassword.UserId = this.userid;
        this.createChangePasswordFormGroup();

        }

    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent,

        private routerObj: Router,
        private route: ActivatedRoute,
        private fb: FormBuilder) {
        super(toasterService, authenticationService, messageEvent);
        this.router = routerObj;
    }
    
    /* end Events Of PayCycle */
    onSavePassword() {
        if (this.isValid()) {
            if (this.selectedChangePassword.NewPassword != this.selectedChangePassword.ConfirmNewPassword) {
                this.showError("Update Password", "NewPassword And ConfirmNewPassword Are Not Matched");
            }            
        }
        this.changePasswordFormGroup.reset();
    }

    onCancel() {
        this.routeUrl = 'dashboard/';
        this.router.navigate([this.routeUrl]);
    }
    createChangePasswordFormGroup() {
        this.changePasswordFormGroup = this.fb.group({
            UserId: new FormControl(this.selectedChangePassword.UserId, Validators.required),
            CurrentPassword: new FormControl(this.selectedChangePassword.CurrentPassword, Validators.required),
            NewPassword: new FormControl(this.selectedChangePassword.NewPassword, Validators.required),
            ConfirmNewPassword: new FormControl(this.selectedChangePassword.ConfirmNewPassword, Validators.required)
        });
    }

    public isValid(): boolean {
        this.ErrorMessages = [];

        this.isStringNullOrEmpty(this.selectedChangePassword.CurrentPassword, "Current password is required");
        this.isStringNullOrEmpty(this.selectedChangePassword.NewPassword, "New password is required");
        this.isStringNullOrEmpty(this.selectedChangePassword.ConfirmNewPassword, "Confirm password is required");
        this.showErrors("Change password validation errors");

        return super.isValid();
    }



}

