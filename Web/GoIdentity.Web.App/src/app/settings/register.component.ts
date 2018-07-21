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
import { ToasterService } from 'angular2-toaster/angular2-toaster';

@Component({
    templateUrl: 'register.component.html',
    providers: [Ng4LoadingSpinnerService]
})
export class RegisterComponent implements OnInit {

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
        private deviceService: DeviceDetectorService,
        private toasterService: ToasterService)
    { }

    ngOnInit() {
        this.spinnerService.show();
        var emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
        this.form = this.fb.group({
            firstname: [null, Validators.compose([Validators.required])],
            lastname: [null, Validators.compose([Validators.required])],
            password: [null, Validators.compose([Validators.required])],
            email: [null, Validators.compose([Validators.required]), Validators.pattern(emailPattern)],
            mobile: [null, Validators.compose([Validators.required])],
            confirmPassword: [null, Validators.compose([Validators.required])],
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
    onSubmit() {
        debugger;
        var deviceInfo = this.deviceService.getDeviceInfo();
        localStorage.setItem("device", (deviceInfo.device == undefined || deviceInfo.device == null) ? "" : deviceInfo.device);
        debugger
        if (this.form.controls['firstname'] == null || this.form.controls['firstname'].value == "" || this.form.controls['firstname'].value == null) {
            this.toasterService.pop('error', '', 'Invalid first name');
            return false;
        }
        if (this.form.controls['lastname'] == null || this.form.controls['lastname'].value == "" || this.form.controls['lastname'].value == null) {
            this.toasterService.pop('error', '', 'Invalid last name');
            return false;
        }
        var isEmailOrMobileNotExists = (this.form.controls['email'] == null || this.form.controls['email'].value == "" || this.form.controls['email'].value == null) && (this.form.controls['mobile'] == null || this.form.controls['mobile'].value == "" || this.form.controls['mobile'].value == null);
        if (isEmailOrMobileNotExists) {
            this.toasterService.pop('error', '', 'Please enter email or phone number');
            return false;
        }
        if (!isEmailOrMobileNotExists && (this.form.controls['mobile'].value != "" && this.form.controls['mobile'].value != null) && (this.form.controls['mobile'].value!=null && (this.form.controls['mobile'].value.length < 10 || this.form.controls['mobile'].value.length > 12 || Number(this.form.controls['mobile'].value) == NaN))) {
            this.toasterService.pop('error', '', 'Invalid phone number');
            return false;
        } 
        if (this.form.controls['password'] == null || this.form.controls['password'].value == "" || this.form.controls['password'].value == null) {
            this.toasterService.pop('error', '', 'Invalid password');
            return false;
        }
        if (this.form.controls['confirmPassword'] == null || this.form.controls['confirmPassword'].value == "" || this.form.controls['confirmPassword'].value == null || this.form.controls['confirmPassword'].value == null || this.form.controls['password'].value == "" || this.form.controls['password'].value != this.form.controls['confirmPassword'].value) {
            this.toasterService.pop('error', '', 'Invalid confirm password');
            return false;
        }
        this.spinnerService.show();
        this.authenticationService.SignUp(this.form.controls['firstname'].value
            , this.form.controls['lastname'].value
            , this.form.controls['email'].value
            , this.form.controls['mobile'].value
            , this.form.controls['password'].value)
            .subscribe(data => {
                this.toasterService.pop('success', '', 'Registered successfully.');
                //this.router.navigate(['/settings/login']);
                this.form.reset();
                this.spinnerService.hide();
            },
            error => {
                this.errorMsg = "Invalid credentials";
                this.spinnerService.hide();
            });
    }
}
