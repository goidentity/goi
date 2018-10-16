import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { Subscription, Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { ChangePassword, Client } from '../models/domain/user-entities';
import { DeviceInfo, DeviceDetectorService } from 'ngx-device-detector';
import { ToasterService } from 'angular2-toaster/angular2-toaster';

import { Component, OnInit, Inject, Input, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';

@Component({
    templateUrl: './myprofile.component.html',
    providers: [Ng4LoadingSpinnerService]
})
export class MyprofileComponent implements OnInit {
    public returnUrl: string;
    public errorMsg: string;
    public client: Client;

    public deviceId: string = "";

    public genders = [
        { name: "Male" },
        { name: "Female" },
        { name: "Other" },
    ];

    public user1 = new User(1, "banu", "saladi", "Male", "sankar");

    constructor(private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private spinnerService: Ng4LoadingSpinnerService,
        private deviceService: DeviceDetectorService,
        private toasterService: ToasterService,
        private userService: UserService) { }


    public onSaveClick() { }
    public onUpdateClick(form: any) {
        console.log(form.value);
        alert("The form was submitted");
        form.reset();
    }

    ngOnInit() {
        //this.getUserProfileData();
        this.spinnerService.show();
        var emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.spinnerService.hide();

        this.route.queryParams.subscribe(params => {
            debugger;
            this.deviceId = params["deviceId"];

            localStorage.setItem("deviceId", (this.deviceId == undefined || this.deviceId == null) ? "" : this.deviceId);
        });
    }

    public onSave() {
        debugger;
        var deviceInfo = this.deviceService.getDeviceInfo();
        localStorage.setItem("device", (deviceInfo.device == undefined || deviceInfo.device == null) ? "" : deviceInfo.device);

        this.spinnerService.show();
    }

    /*

        this.userService.createUserProfile(this.form.controls['firstname'].value
            , this.form.controls['lastname'].value
            , this.form.controls['middlename'].value
            , this.form.controls['displayname'].value
            , this.form.controls['dob'].value
            , this.form.controls['mobilenumber'].value
            , this.form.controls['alternatenumber'].value
            , this.form.controls['email'].value
            , this.form.controls['address1'].value)
            .subscribe(data => {
                this.toasterService.pop('success', '', 'Profile Created successfully.');
                //this.router.navigate(['/settings/login']);
                this.form.reset();
                this.spinnerService.hide();
            },
            error => {
                this.errorMsg = "Invalid data exists";
                this.spinnerService.hide();
            });
    */

}
export class User {
    constructor(
        public id: number,
        public firstName: string,
        public lastName: string,
        public gender: string,
        public middleName?: string
    ) { }
}


