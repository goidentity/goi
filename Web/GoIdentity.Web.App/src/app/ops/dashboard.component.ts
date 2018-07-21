import { Component, OnInit, Inject, Input, OnDestroy, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription ,  Observable } from 'rxjs';

import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';
import { ScoreService } from '../services/score.service';

@Component({
    templateUrl: './dashboard.component.html',
    providers: [ScoreService]
})
export class DashboardComponent extends BaseComponent implements OnInit, AfterViewInit {
    public router: Router;
    public OpenPanelDialogStatus: boolean;
    public dataSetsGridView: Array<any>; 

    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent,

        public scoreService: ScoreService,

        private routerObj: Router) {
        super(toasterService, authenticationService, messageEvent);
        this.router = routerObj;
    }

    ngOnInit() {
        
    }

    private scoreData: any[];

    ngAfterViewInit() {
        this.scoreService.getLatestScoreByUserId(Number.parseInt(localStorage.getItem('UserId'))).subscribe(data => {
            this.scoreData = [];
            var row = { Industry: '', Weightage: 0, data: [] as any[] };
            var fullLength = data.length;

            data.forEach((d, i) => {
                var nextEntry = (i+1 > fullLength-1) ? '': data[i + 1].Industry;
                if (nextEntry != d.Industry) {
                    row.Industry = d.Industry;
                    row.Weightage = d.IndustryWeightage;
                    this.scoreData.push(row);
                    //re initiate
                    row = { Industry: d.Industry, Weightage: d.IndustryWeightage, data: [] };
                }
                row.data.push({ Category: d.Category, Score: d.Score });
            });
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


