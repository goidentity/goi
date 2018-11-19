import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SeriesLabels } from '@progress/kendo-angular-charts';
import { ToasterService } from "angular2-toaster";
import { MessageEvent } from '../models/utilities/broadcaster';
import { AuthenticationService } from '../services/authentication.service';
import { ScoreService } from '../services/score.service';
import { BaseComponent } from '../shared/base-component';
import { UserService } from '../services/user.service';

@Component({
    templateUrl: './dashboard.component.html',
    providers: [ScoreService]
})
export class DashboardComponent extends BaseComponent implements OnInit, AfterViewInit {

    public router: Router;
    public scoresList: any[] = [];

    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent,
        private userService: UserService,

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
        this.userService.getUserScores().subscribe(s => {
            this.scoresList = s;
        });
    }

    public labelContent(e: any): string {
        return e.category;
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

    iproGridDelete(index: number) {
        debugger;
        this.targetList.splice(index, 1);

    }

}
class Widget {
    constructor(public name: string) { }
}


