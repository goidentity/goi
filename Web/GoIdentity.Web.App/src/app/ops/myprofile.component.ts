import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { Subscription, Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { ChangePassword, Client, MyUserProfile } from '../models/domain/user-entities';
import { DeviceInfo, DeviceDetectorService } from 'ngx-device-detector';
import { ToasterService } from 'angular2-toaster/angular2-toaster';

import { Component, OnInit, Inject, Input, OnDestroy, NgZone, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';
import { Element } from '@progress/kendo-drawing';
import { element } from '@angular/core/src/render3/instructions';

@Component({
    templateUrl: './myprofile.component.html',
    providers: [Ng4LoadingSpinnerService]
})
export class MyprofileComponent implements OnInit {
    public returnUrl: string;
    public errorMsg: string;
    public client: Client;
    public currentUser: MyUserProfile;
    public user: MyUserProfile;


    public deviceId: string = "";

    public genders = [
        { name: "Male" },
        { name: "Female" },
        { name: "Other" },
    ];
    public maritialStatuses = [
        { name: "Single" },
        { name: "Married" },
        { name: "Divorced" },
    ];

    public editMode: boolean = false;

    constructor(private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private spinnerService: Ng4LoadingSpinnerService,
        private deviceService: DeviceDetectorService,
        private toasterService: ToasterService,
        private userService: UserService,
        private zone: NgZone) { }


    public onSaveClick() { }
    public onSubmitClick(form: any) {
        console.log(form.value);
        alert("The form was submitted");
        this.user = this.currentUser;
        console.log(JSON.stringify(this.user));
        this.userService.updateMyUserProfile(this.currentUser);
        this.editMode = false;
    }

    setAddress(event: any) {
        console.log(event.target);
        this.zone.run(() => {
            this.currentUser[event.target] = event.address.formatted_address;
        });
    }

    ngOnInit() {
        this.getUserProfileData();
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
    getUserProfileData() {
        //this.currentUser = new MyUserProfile(1, "banu", "saladi", "Male", "bhanu499@gmail.com", "9642013699", "sankar", new Date(1990, 10, 26), "Hyderabad, Telangana, India");
        this.userService.getMyUserProfile().subscribe(data => {
            this.user = data;
            this.currentUser = data;
        })
    }
    toggleEdit() {
        this.editMode = !this.editMode;
    }
    onCancel(event:any) {
        this.editMode = false;
        this.currentUser = this.user;
        event.preve
    }
    
}


