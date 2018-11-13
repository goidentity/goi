import { Component, OnInit, Inject, Input, OnDestroy, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription, Observable } from 'rxjs';

import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';
import { ScoreService } from '../services/score.service';
import { forEach } from '@angular/router/src/utils/collection';
import { ChartsModule, SeriesLabels } from '@progress/kendo-angular-charts';

@Component({
    templateUrl: './dashboard.component.html',
    providers: [ScoreService]
})
export class DashboardComponent extends BaseComponent implements OnInit, AfterViewInit {
 public series: any[] = [{
        type: 'column',
        data: [20, 40, 45, 30, 50],
        stack: true,
        name: 'on battery',
        color: '#cc6e38'
    }, {
        type: 'column',
        data: [20, 30, 35, 35, 40],
        stack: true,
        name: 'on gas',
        color: '#ef955f'
    }, {
        type: 'line',
        data: [30, 38, 40, 32, 42],
        name: 'mpg',
        color: '#ec5e0a',
        axis: 'mpg'
    }, {
        type: 'line',
        data: [7.8, 6.2, 5.9, 7.4, 5.6],
        name: 'l/100 km',
        color: '#4e4141',
        axis: 'l100km'
    }];

    public valueAxes: any[] = [{
        title: 'miles',
        min: 0,
        max: 100
    }, {
        name: 'km',
        title: 'km',
        min: 0,
        max: 161,
        majorUnit: 32
    }, {
        name: 'mpg',
        title: 'miles per gallon',
        color: '#ec5e0a'
    }, {
        name: 'l100km',
        title: 'liters per 100km',
        color: '#4e4141'
    }];

    

    // Align the first two value axes to the left
    // and the last two to the right.
    //
    // Right alignment is done by specifying a
    // crossing value greater than or equal to
    // the number of categories.
    public crossingValues: number[] = [0, 0, 10, 10];
    public router: Router;
    public OpenPanelDialogStatus: boolean;
    public dataSetsGridView: Array<any>;
    public seriesData: number[] = [20, 40, 45, 30, 50];
    public categories: string[] = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'];
    public seriesData1: number[] = [1, 2, 3, 5];
    public pieData: any = [
        { category: 'Eaten', value: 0.42 },
        { category: 'Not eaten', value: 0.58 }
    ]
    public seriesData2: number[] = [20, 40, 45, 30, 50];
    public categories1: string[] = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'];

    public seriesLabels: SeriesLabels = {
        visible: true, // Note that visible defaults to false
        padding: 3,
        font: 'bold 16px Arial, sans-serif'
    };
    public data12: any[] = [{
        kind: 'Hydroelectric', share: 0.175
    }, {
        kind: 'Nuclear', share: 0.238
    }, {
        kind: 'Coal', share: 0.118
    }, {
        kind: 'Solar', share: 0.052
    }, {
        kind: 'Wind', share: 0.225
    }, {
        kind: 'Other', share: 0.192
    }];

    public labelContent(e: any): string {
        return e.category;
    }

    public model = [{
        stat: 'Impressions ',
        count: 434823,
        color: '#0e5a7e'
    }, {
        stat: 'Clicks',
        count: 356854,
        color: '#166f99'
    }, {
        stat: 'Unique Visitors',
        count: 280022,
        color: '#2185b4'
    }, {
        stat: 'Downloads',
        count: 190374,
        color: '#319fd2'
    }, {
        stat: 'Purchases',
        count: 120392,
        color: '#3eaee2'
    }];

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
                if (nextEntry != '' && d.Industry != nextEntry)
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
                    if (d.Score > 0) this.positiveScore = this.positiveScore + d.Score;
                    if (d.Score < 0) this.negativeScore = this.negativeScore + d.Score;
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


