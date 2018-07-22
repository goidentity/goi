import { Component, OnInit, Inject, Input, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription ,  Observable } from 'rxjs';

import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';

@Component({
    templateUrl: './myprofile.component.html',
    providers: []
})
export class MyprofileComponent extends BaseComponent implements OnInit {
    public router: Router;
    public OpenPanelDialogStatus: boolean;
    public dataSetsGridView: Array<any>;
    public form: any;
    public errorMsg: any;

    public onSave(){}
    public onSaveClick() {}
    public onUpdateClick() {}

    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public userService: UserService,
        public messageEvent: MessageEvent,

        private routerObj: Router) {
        super(toasterService, authenticationService, messageEvent);
        this.router = routerObj;
    }

    ngOnInit() {        
        this.getUserProfileData();
    }
    private getUserProfileData(): void {
        this.userService.getUserProfile().subscribe(data =>{
console.log(data);
});
    }
    sourceList: Widget[] = [
        new Widget('onebyone'),
        new Widget('twobytwo'),
        new Widget('twobyfour'),
        new Widget('fourbytwo'),
        new Widget('fourbyfour'),
        new Widget('fivebytwo'),
        new Widget('fivebyfour')
    ];
    targetList: Widget[] = [];
    addTo($event: any) {
        debugger;
        this.targetList.push($event.dragData);
    }
    /* Init */
    

    iproGridSettings() {
      this.OpenPanelDialogStatus = true;
    }


    iproGridDelete(index: number) {
        debugger;
        this.targetList.splice(index,1);        
       
    }


     closePanel() {
         this.OpenPanelDialogStatus = false;
     }

    


}
class Widget {
    constructor(public name: string) { }
}


