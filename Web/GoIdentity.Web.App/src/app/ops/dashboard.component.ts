import { Component, OnInit, Inject, Input, OnDestroy, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription, Observable } from 'rxjs';

import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';
import { ScoreService } from '../services/score.service';
import { forEach } from '@angular/router/src/utils/collection';

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

    public scoreData: any[];
    public positiveScore: number = 0;
    public negativeScore: number = 0;
    public neutralScore: number = 0;

    public positiveLastScore: number = 0;
    public negativeLastScore: number = 0;
    public neutralLastScore: number = 0;

    public finalScore: number = 0;
    public finalLastScore: number = 0;

    ngAfterViewInit() {
        this.scoreService.getLatestScoreByUserId(Number.parseInt(localStorage.getItem('UserId'))).subscribe(data => {
            let hasMoreIndustries = 0;
            this.scoreData = [];
            //find if more industries
            data.forEach((d, i) => {
                var nextEntry = (i + 1 > data.length - 1) ? '' : data[i + 1].Industry;
                if (nextEntry !='' && d.Industry != nextEntry)
                    hasMoreIndustries = 1;
            });
            // process data
            data.forEach((d, i) => {
                
                if (hasMoreIndustries == 1) {
                    var cScore = 0;
                    var lScore = 0;
                    this.scoreData.forEach(s => {
                        if (s.key == d.Category) {
                            cScore = cScore + d.Score * d.IndustryWeightage;
                            lScore = lScore + d.LastScore * d.IndustryWeightage;
                        };
                    })
                    this.scoreData.push({ key: d.Category, score: cScore, lastScore: lScore });
                    //calculate negative/positive score
                    if (d.Score > 0) this.positiveScore = this.positiveScore + d.Score * d.IndustryWeightage;
                    if (d.Score < 0) this.negativeScore = this.negativeScore + d.Score * d.IndustryWeightage;
                    if (d.LastScore > 0) this.positiveScore = this.positiveLastScore + d.LastScore * d.IndustryWeightage;
                    if (d.LastScore < 0) this.negativeScore = this.negativeLastScore + d.LastScore * d.IndustryWeightage;
                    
                }
                else {
                    this.scoreData.push({ key: d.Category, score: d.Score, lastScore: d.LastScore });
                    if (d.Score > 0) this.positiveScore = this.positiveScore + d.Score ;
                    if (d.Score < 0) this.negativeScore = this.negativeScore + d.Score ;
                    if (d.LastScore > 0) this.positiveScore = this.positiveLastScore + d.LastScore;
                    if (d.LastScore < 0) this.negativeScore = this.negativeLastScore + d.LastScore;
                }
                    
            });
            this.finalScore = this.positiveScore + this.negativeScore + this.neutralScore;
            this.finalLastScore = this.positiveLastScore + this.negativeLastScore + this.neutralLastScore;
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
        this.targetList.splice(index, 1);

    }


    closePanel() {
        this.OpenPanelDialogStatus = false;
    }




}
class Widget {
    constructor(public name: string) { }
}


