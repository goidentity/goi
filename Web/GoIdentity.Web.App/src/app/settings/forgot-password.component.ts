import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { Subscription, Observable } from 'rxjs';
import { UserService } from '../services/user.service';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { ChangePassword, Client } from '../models/domain/user-entities';
import { DeviceInfo, DeviceDetectorService } from 'ngx-device-detector';
import { ToasterService } from 'angular2-toaster/angular2-toaster';

@Component({
    templateUrl: './forgot-password.component.html',
    providers: [Ng4LoadingSpinnerService, UserService]
})
export class ForgotPasswordComponent implements OnInit {

    /* Change Password Variables */
    public forgetform: FormGroup;
    public returnUrl: string;
    public errorMsg: string;
    public client: Client;

    public deviceId: string = "";

    ngOnInit() {
        this.spinnerService.show();
        this.forgetform = this.fb.group({
            uname: [null, Validators.compose([Validators.required])]
        });

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.spinnerService.hide();

        this.route.queryParams.subscribe(params => {
            debugger;
            this.deviceId = params["deviceId"];

            localStorage.setItem("deviceId", (this.deviceId == undefined || this.deviceId == null) ? "" : this.deviceId);
        });
    }

    constructor(private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private userService: UserService,
        private spinnerService: Ng4LoadingSpinnerService,
        private deviceService: DeviceDetectorService,
        private toasterService: ToasterService) { }

    onSubmit() {
        debugger;
        var deviceInfo = this.deviceService.getDeviceInfo();
        localStorage.setItem("device", (deviceInfo.device == undefined || deviceInfo.device == null) ? "" : deviceInfo.device);
        if (this.forgetform.controls['uname'] == null || this.forgetform.controls['uname'].value == "" || this.forgetform.controls['uname'].value == null) {
            this.toasterService.pop('error', '', 'Invalid Email/Phone number');
            return false;
        }
        this.spinnerService.show();
        this.userService.forgotPassword(this.forgetform.controls['uname'].value)
            .subscribe(data => {
                this.spinnerService.hide();
                this.forgetform.reset();
                //setTimeout(() => { this.router.navigate(['settings/login']); }, 2000);
            },
            error => {
                this.errorMsg = "Invalid credentials";
                this.spinnerService.hide();
            });
    }



}

