import { Component, OnInit, Inject, Input, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription, Observable } from 'rxjs';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { ToasterService } from "angular2-toaster";
import { AuthenticationService } from '../services/authentication.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { BaseComponent } from '../shared/base-component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { DialogModule } from '@progress/kendo-angular-dialog';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { products } from './product_Demo';

@Component({
    templateUrl: './profile.component.html',
    providers: []
})
export class ProfileComponent extends BaseComponent implements OnInit {
    public router: Router;
    public OpenPanelDialogStatus: boolean;
    public OpenConfirmationStatus1: boolean;
    public dataSetsGridView: Array<any>;
    public EducationData: any[] = products;
    public gender: Array<string> = ["Male", "Female"];
    public Maritial: Array<string> = ["Single", "Married"];
    public Nationality: Array<string> = ["Indian", "USA", "Astralian", "Singapure"];
    public Nationality1: Array<string> = ["Indian", "USA", "Astralian", "Singapure"];
    public Nationality2: Array<string> = ["Indian", "USA", "Astralian", "Singapure"];
    public Industries: Array<string> = ["Agriculture and Allied Industries", "Automobiles", "Auto Components", "Aviation", "Banking", "Cement", "Consumer Durables", "Ecommerce", "Education and Training", "Engineering and Capital Goods", "Financial Services"
        , "FMCG"
        , "Gems and Jewellery"
        , "Healthcare"
        , "Infrastructure"
        , "Insurance"
        , "IT and ITeS"
        , "Manufacturing"
        , "Media and Entertainment"
        , "Metals And Mining"
        , "Oil and Gas"
        , "Pharmaceuticals"
        , "Ports"
        , "Power"
        , "Railways"
        , "Real Estate"
        , "Renewable Energy"
        , "Retail"
        , "Roads"
        , "Science and Technology"
        , "Services"
        , "Steel"
        , "Telecommunications"
        , "Textiles"
        , "Tourism and Hospitality"];

    public selectedValue: string = "Male";
    public selectedValue1: string = "Single";
    public selectedNationality: string = "Indian";
    public selectedNationality1: string = "Indian";
    public selectedPRStatus: any = ['Indian'];
    public value: Date = new Date();
    public value1: Date = new Date();
    public value2: Date = new Date();
    public value3: Date = new Date();
    public Industries1: Array<string> = ["Agriculture and Allied Industries", "Automobiles", "Auto Components", "Aviation", "Banking", "Cement", "Consumer Durables", "Ecommerce", "Education and Training", "Engineering and Capital Goods", "Financial Services"
        , "FMCG"
        , "Gems and Jewellery"
        , "Healthcare"
        , "Infrastructure"
        , "Insurance"
        , "IT and ITeS"
        , "Manufacturing"
        , "Media and Entertainment"
        , "Metals And Mining"
        , "Oil and Gas"
        , "Pharmaceuticals"
        , "Ports"
        , "Power"
        , "Railways"
        , "Real Estate"
        , "Renewable Energy"
        , "Retail"
        , "Roads"
        , "Science and Technology"
        , "Services"
        , "Steel"
        , "Telecommunications"
        , "Textiles"
        , "Tourism and Hospitality"];
    public Industries2: Array<string> = ["Agriculture and Allied Industries", "Automobiles", "Auto Components", "Aviation", "Banking", "Cement", "Consumer Durables", "Ecommerce", "Education and Training", "Engineering and Capital Goods", "Financial Services"
        , "FMCG"
        , "Gems and Jewellery"
        , "Healthcare"
        , "Infrastructure"
        , "Insurance"
        , "IT and ITeS"
        , "Manufacturing"
        , "Media and Entertainment"
        , "Metals And Mining"
        , "Oil and Gas"
        , "Pharmaceuticals"
        , "Ports"
        , "Power"
        , "Railways"
        , "Real Estate"
        , "Renewable Energy"
        , "Retail"
        , "Roads"
        , "Science and Technology"
        , "Services"
        , "Steel"
        , "Telecommunications"
        , "Textiles"
        , "Tourism and Hospitality"];
    public Industries3: Array<string> = ["Agriculture and Allied Industries", "Automobiles", "Auto Components", "Aviation", "Banking", "Cement", "Consumer Durables", "Ecommerce", "Education and Training", "Engineering and Capital Goods", "Financial Services"
        , "FMCG"
        , "Gems and Jewellery"
        , "Healthcare"
        , "Infrastructure"
        , "Insurance"
        , "IT and ITeS"
        , "Manufacturing"
        , "Media and Entertainment"
        , "Metals And Mining"
        , "Oil and Gas"
        , "Pharmaceuticals"
        , "Ports"
        , "Power"
        , "Railways"
        , "Real Estate"
        , "Renewable Energy"
        , "Retail"
        , "Roads"
        , "Science and Technology"
        , "Services"
        , "Steel"
        , "Telecommunications"
        , "Textiles"
        , "Tourism and Hospitality"];

    public EdcuationType: Array<string> = ["Doctorate", "Masters", "Post Graduation", "Graduation+2", "Specialisation"];
    public EdcuationType2: Array<string> = ["Doctorate", "Masters", "Post Graduation", "Graduation+2", "Specialisation"];
    public EdcuationType3: Array<string> = ["Doctorate", "Masters", "Post Graduation", "Graduation+2", "Specialisation"];
    public selectedEdcuationType: any = ["Doctarate"];
    public selectedIndustries: any = ["Textiles"];
    public selectedIndustries1: any = ["Textiles"];
    public selectedIndustries2: any = ["Textiles"];
    public selectedIndustries3: any = ["Textiles"];
    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent,

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
        this.targetList.splice(index, 1);

    }


    closePanel() {
        this.OpenPanelDialogStatus = false;
    }


    public addEducation() {
        this.IsNew = true;
        this.DialogTitle = "Add Education";
        this.OpenDialogStatus = true;
        debugger;
    }
    public addEmployment() {
        this.IsNew = true;
        this.DialogTitle = "Add Employment";
        this.OpenDialogStatus1 = true;
        debugger;
    }
    public closeConfirmation() {
        this.OpenConfirmationStatus1 = false;
    }
    public closeDialog1() {
        this.OpenDialogStatus1 = false;
    }
    public onSave() {
        debugger;
    }

}
class Widget {
    constructor(public name: string) { }
}


