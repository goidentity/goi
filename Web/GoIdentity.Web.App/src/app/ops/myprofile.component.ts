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
        private toasterService: ToasterService,
        private userService: UserService) { }

    public onSave(){}
    public onSaveClick() {}
    public onUpdateClick() {}   

    ngOnInit() {        
        //this.getUserProfileData();
        this.spinnerService.show();
        var emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
        this.form = this.fb.group({
            firstname: [null, Validators.compose([Validators.required])],
            lastname: [null, Validators.compose([Validators.required])],
            middlename: [null, Validators.compose([Validators.required])],
            dob: [null, Validators.compose([Validators.required])],
            displayname: [null, Validators.compose([Validators.required])],
            gender: [null, Validators.compose([Validators.required])],
            email: [null, Validators.compose([Validators.required]), Validators.pattern(emailPattern)],
            mobilenumber: [null, Validators.compose([Validators.required])],
            alternatenumber: [null, Validators.compose([Validators.required])],
            address1: [null, Validators.compose([Validators.required])],
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
        if (this.form.controls['dob'] == null || this.form.controls['dob'].value == "" || this.form.controls['dob'].value == null) {
            this.toasterService.pop('error', '', 'Invalid DOB');
            return false;
        }
        if (this.form.controls['displayname'] == null || this.form.controls['displayname'].value == "" || this.form.controls['displayname'].value == null) {
            this.toasterService.pop('error', '', 'Invalid last name');
            return false;
        }
        var isEmailOrMobileNotExists = (this.form.controls['email'] == null || this.form.controls['email'].value == "" || this.form.controls['email'].value == null) && (this.form.controls['mobilenumber'] == null || this.form.controls['mobilenumber'].value == "" || this.form.controls['mobilenumber'].value == null);
        if (isEmailOrMobileNotExists) {
            this.toasterService.pop('error', '', 'Please enter email or phone number');
            return false;
        }
        if (!isEmailOrMobileNotExists && (this.form.controls['mobilenumber'].value != "" && this.form.controls['mobilenumber'].value != null) && (this.form.controls['mobilenumber'].value != null && (this.form.controls['mobilenumber'].value.length < 10 || this.form.controls['mobilenumber'].value.length > 12 || Number(this.form.controls['mobilenumber'].value) == NaN))) {
            this.toasterService.pop('error', '', 'Invalid phone number');
            return false;
        }
        if (this.form.controls['gender'] == null || this.form.controls['gender'].value == "" || this.form.controls['gender'].value == null) {
            this.toasterService.pop('error', '', 'Invalid Gender');
            return false;
        }
        if (this.form.controls['address1'] == null || this.form.controls['address1'].value == "" || this.form.controls['address1'].value == null) {
            this.toasterService.pop('error', '', 'Invalid Address1');
            return false;
        }
        this.spinnerService.show();
        this.userService.createUserProfile(this.form.controls['firstname'].value
            , this.form.controls['lastname'].value
            ,this.form.controls['middlename'].value
            , this.form.controls['displayname'].value
            ,this.form.controls['dob'].value
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
    }
//    private getUserProfileData(): void {
//        this.userService.getUserProfile().subscribe(data =>{
//console.log(data);
//});
//    }
//    sourceList: Widget[] = [
//        new Widget('onebyone'),
//        new Widget('twobytwo'),
//        new Widget('twobyfour'),
//        new Widget('fourbytwo'),
//        new Widget('fourbyfour'),
//        new Widget('fivebytwo'),
//        new Widget('fivebyfour')
//    ];
//    targetList: Widget[] = [];
//    addTo($event: any) {
//        debugger;
//        this.targetList.push($event.dragData);
//    }
//    /* Init */
    

//    iproGridSettings() {
//      this.OpenPanelDialogStatus = true;
//    }


//    iproGridDelete(index: number) {
//        debugger;
//        this.targetList.splice(index,1);        
       
//    }


//     closePanel() {
//         this.OpenPanelDialogStatus = false;
//     }

}
class Widget {
    constructor(public name: string) { }
}


