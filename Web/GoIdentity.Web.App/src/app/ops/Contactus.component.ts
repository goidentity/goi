import { Component, OnInit, Inject, Input, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription ,  Observable } from 'rxjs';

import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';
import { AuthDataService } from '../services/authdata.service';
@Component({
    templateUrl: './contactus.component.html',
    providers: [AuthDataService]
})
export class ContactusComponent extends BaseComponent implements OnInit {
    public router: Router;
    public OpenPanelDialogStatus: boolean;
    public dataSetsGridView: Array<any>; 

    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent,
        public authDataService : AuthDataService,
        private routerObj: Router) {
        super(toasterService, authenticationService, messageEvent);
        this.router = routerObj;
    }

    ngOnInit() {
        
        this.getReportData();
    }
    private getReportData(): void {
        
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

    onClick() {
        this.authDataService.getAuthUrl().subscribe(data => {
            window.location.href = data.Url;
        });
    }


}
class Widget {
    constructor(public name: string) { }
}


