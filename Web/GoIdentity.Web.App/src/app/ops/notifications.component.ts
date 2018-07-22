import { Component, OnInit, Inject, Input, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ModalModule } from 'ngx-bootstrap/modal';

import { Subscription, Observable } from 'rxjs';

import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { ScoreService } from '../services/score.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';

@Component({
    templateUrl: './notifications.component.html',
    providers: [ScoreService, ModalModule]
})
export class NotificationsComponent extends BaseComponent implements OnInit {
    public router: Router;
    public OpenPanelDialogStatus: boolean;
    public dataSetsGridView: Array<any>;

    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent,
        public scoreService: ScoreService,
        public modalModule: ModalModule,
        private routerObj: Router) {
        super(toasterService, authenticationService, messageEvent);
        this.router = routerObj;
    }

    ngOnInit() {
        this.getNotificationData();
    }

    public notificationData: any[];

    private getNotificationData(): void {
        this.scoreService.getNotifications(Number.parseInt(localStorage.getItem('UserId'))).subscribe(data => {
            debugger
            this.notificationData = data;
        });
    }

    onDelete(userNotificationId: number) {
        //this.modalModule.();
        //console.log(userNotificationId)
    }
    onEdit(userNotificationId: number) {

        //console.log(userNotificationId)

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
        this.targetList.splice(index, 1);

    }


    closePanel() {
        this.OpenPanelDialogStatus = false;
    }




}
class Widget {
    constructor(public name: string) { }
}


