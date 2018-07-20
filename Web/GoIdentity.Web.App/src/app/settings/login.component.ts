import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { Subscription, Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { ChangePassword, Client } from '../models/domain/user-entities';
import { DeviceInfo, DeviceDetectorService } from 'ngx-device-detector';

@Component({
    templateUrl: 'login.component.html',
    providers: [Ng4LoadingSpinnerService]
})
export class LoginComponent implements OnInit {

    public form: FormGroup;
    public returnUrl: string;
    public errorMsg: string;
    public client: Client;

    public deviceId: string = "";

    constructor(private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private spinnerService: Ng4LoadingSpinnerService,
        private deviceService: DeviceDetectorService)
    { }

    ngOnInit() {
        this.spinnerService.show();
        this.form = this.fb.group({
            uname: [null, Validators.compose([Validators.required])],
            password: [null, Validators.compose([Validators.required])],
            AuthenticationCode: [null]
        });

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.spinnerService.hide();
        
        this.route.queryParams.subscribe(params => {
            debugger;
            this.deviceId = params["deviceId"];

            localStorage.setItem("deviceId", (this.deviceId == undefined || this.deviceId == null) ? "" : this.deviceId);
        });
    }
    //https://d.bhashyam.in/#/settings/login
    onSubmit() {
        debugger;
        var deviceInfo = this.deviceService.getDeviceInfo();

        localStorage.setItem("device", (deviceInfo.device == undefined || deviceInfo.device == null) ? "" : deviceInfo.device);
        
        this.spinnerService.show();
        this.authenticationService.SignIn(this.form.controls['uname'].value
            , this.form.controls['password'].value
            , this.form.controls['AuthenticationCode'].value)
            .subscribe(data => {
                this.router.navigate([this.returnUrl]);
                this.spinnerService.hide();
            },
            error => {
                this.errorMsg = "Invalid credentials";
                this.spinnerService.hide();
            });
    }
}
