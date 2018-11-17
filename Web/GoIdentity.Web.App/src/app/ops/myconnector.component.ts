import { Component, OnInit, Inject, Input, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription, Observable } from 'rxjs';

import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';
import { AuthDataService } from '../services/authdata.service';
import { ConnectorService } from '../services/connector.service';

@Component({
    templateUrl: './myconnector.component.html',
    providers: [AuthDataService, ConnectorService]
})
export class MyConnectorComponent extends BaseComponent implements OnInit {
    constructor(public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent,
        public connectorService : ConnectorService) {
        super(toasterService, authenticationService, messageEvent);
    }
    ngOnInit(): void {
        throw new Error("Method not implemented.");
    }
    onClick(socialType:string) {
        if (socialType == 'linkedin') {
            this.connectorService.connectLinkedIn().subscribe(data => { window.location.href = data.Url; });
        } else if (socialType == 'facebook') {
            this.connectorService.connectFacebook().subscribe(data => { window.location.href = data.Url; });
        } else if (socialType == 'twitter') {
            this.connectorService.connectTwitter().subscribe(data => { window.location.href = data.Url; });
        } else if (socialType == 'googleplus') {
            this.connectorService.connectGooglePlus().subscribe(data => { window.location.href = data.Url; });
        } else if (socialType == 'instagram') {
            this.connectorService.connectInstagram().subscribe(data => { window.location.href = data.Url; });
        } else if (socialType == 'pinterest') {
            this.connectorService.connectPinterest().subscribe(data => { window.location.href = data.Url; });
        }
    }
}