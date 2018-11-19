import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToasterService } from "angular2-toaster";
import { User, UserEducation, UserExperience } from '../models/domain/user-entities';
import { MessageEvent } from '../models/utilities/broadcaster';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';
import { BaseComponent } from '../shared/base-component';
import { products } from './product_Demo';

@Component({
    templateUrl: './profile.component.html',
    providers: []
})
export class ProfileComponent extends BaseComponent implements OnInit, AfterViewInit {

    public user: User;

    public router: Router;
    public OpenPanelDialogStatus: boolean;
    public OpenConfirmationStatus1: boolean;
    public dataSetsGridView: Array<any>;
    public EducationData: any[] = products;
    public gendersList: Array<string> = ["Male", "Female"];
    public maritalStatusesList: Array<string> = ["Single", "Married", "Separated", "Divorced", "Divorced"];
    public nationalitiesList: Array<string> = ["Indian", "USA", "Astralian", "Singapure"];

    public industriesList: Array<string> = ["Agriculture and Allied Industries", "Automobiles", "Auto Components", "Aviation", "Banking", "Cement", "Consumer Durables", "Ecommerce", "Education and Training", "Engineering and Capital Goods", "Financial Services"
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

    public edcuationTypeList: Array<string> = ["Doctorate", "Masters", "Post Graduation", "Graduation", "+2", "10th", "Specialisation"];

    public selectedUserEducation: UserEducation;
    public selectedUserExperience: UserExperience;

    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent,
        private userService: UserService,

        private routerObj: Router) {
        super(toasterService, authenticationService, messageEvent);
        this.router = routerObj;
    }

    ngOnInit() {


    }

    ngAfterViewInit(): void {
        this.userService.getUserProfile().subscribe(u => {
            this.user = u;
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


    public onAddEducation() {
        this.selectedUserEducation = new UserEducation();
        this.IsNew = true;
        this.DialogTitle = "Add Education";
        this.OpenDialogStatus = true;
    }

    public onSaveEducation() {
        this.user.Education.push(this.selectedUserEducation);
        this.IsNew = true;
        this.DialogTitle = "Add Education";
        this.OpenDialogStatus = false;
    }

    public onCloseEducation() {
        this.OpenDialogStatus = false;
    }

    public onAddEmployment() {
        this.selectedUserExperience = new UserExperience();
        this.IsNew = true;
        this.DialogTitle = "Add Employment";
        this.OpenDialogStatus1 = true;
        debugger;
    }

    public onSaveEmployment() {
        this.user.Experience.push(this.selectedUserExperience);
        this.IsNew = true;
        this.DialogTitle = "Add Experience";
        this.OpenDialogStatus1 = false;
    }

    public onCloseEmployment() {
        this.OpenDialogStatus1 = false;
    }

    public closeConfirmation() {
        this.OpenConfirmationStatus1 = false;
    }
    public closeDialog1() {
        this.OpenDialogStatus1 = false;
    }

    public onCancel() {
        this.userService.getUserProfile().subscribe(u => {
            this.user = u;
        });
    }

    public onSave() {
        this.userService.updateUserProfile(this.user).subscribe(u => {
            this.showSuccess("Success", "Profile updated successfully");
        });
    }

}
class Widget {
    constructor(public name: string) { }
}


