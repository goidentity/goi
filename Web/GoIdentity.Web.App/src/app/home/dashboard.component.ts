import { Component, OnInit, Inject, Input, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { ButtonsModule } from '@progress/kendo-angular-buttons';

import { SortableModule } from '@progress/kendo-angular-sortable';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AccordionModule } from 'ngx-bootstrap';

import { LookupConstants, LookupDetailConstants } from '../models/utilities/lookup-constants';
import { LookupUtilities, FieldEntities } from '../models/utilities/lookup-utilities';
import { BaseComponent } from '../shared/base-component';
import { LookUpDetail } from '../models/domain/lookup-entities';
import { Navigation, NavigationTreeItem } from "../models/domain/user-entities";
import { ReportCol, ReportDocument, ReportTableMapping, SuiteReport, DbObjectField, ReportSource, vReportDoc } from '../models/tb/report-entities';

import { Subscription ,  Observable } from 'rxjs';

import { InputItems, DocumentPanel, DocumentPanelLayouts, DocumentDataSetDetail, DocumentRow, DocumentFields, Doc, InputDataType, vFieldMetaList } from "../models/tb/tb-entities";
import { ItemValue } from "../models/utilities/handy-entities";

import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styles: [' app-dashboard { position: relative;overflow: scroll;}'],
    providers: []
})
export class DashboardComponent extends BaseComponent implements OnInit {
    public router: Router;
    public gridTemplateFormGroup: FormGroup;
    public OpenPanelDialogStatus: boolean;
    public dataSetsGridView: Array<vReportDoc>; 


    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent,

        private routerObj: Router) {
        super(toasterService, authenticationService, messageEvent);
        this.router = routerObj;
    }

    ngOnInit() {
        if (!this.authenticationService.isLoggedIn()) {
            var routeUrl: string = 'api/ScoreApi/GetLatestScoreByUserId/1'; //'home/' + 'dashboard/';
            this.router.navigate([routeUrl]);
        }
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

    


}
class Widget {
    constructor(public name: string) { }
}


