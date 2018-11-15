import { Injectable, HostListener, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable ,  Subject } from 'rxjs';
import { ToasterService, ToasterConfig, BodyOutputType } from 'angular2-toaster/angular2-toaster';
import { MyConstants } from '../models/domain/my-constants';
import { DataSourceRequestState, DataResult, process } from '@progress/kendo-data-query';
import { Employee, vEmployee } from '../models/domain/user-entities';
import { TreeviewConfig } from 'ngx-treeview';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticationService } from '../services/authentication.service';

@Injectable()
export class BaseComponent {
    public treeConfig: TreeviewConfig;

    public toasterconfig: ToasterConfig = new ToasterConfig({
        tapToDismiss: true,
        timeout: 5000,
        bodyOutputType: BodyOutputType.TrustedHtml
    });

    constructor(public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public messageEvent: MessageEvent) {
        this.IsLoading = false;
        this.ErrorMessages = [];

        if (localStorage.getItem("SelectedEmployee") != null) {
            this.SelectedEmployee = JSON.parse(localStorage.getItem("SelectedEmployee"));
        }

        this.treeConfig = TreeviewConfig.create({
            hasAllCheckBox: true,
            hasFilter: true,
            hasCollapseExpand: true,
            decoupleChildFromParent: false,
            maxHeight: 400
        });

        this.authenticationService.refreshToken();
    }

    public pageSize = 20;
    public skip = 0;

    public DataGridState: DataSourceRequestState = {
        skip: 0,
        take: 20,
        sort: [],
        filter: {
            logic: 'and',
            filters: []
        },
        group: []
    };

    /* Selectors */
    public SelectedEmployee: Employee;

    /* Constants */
    public InputdDateFormat: string = "dd-MMM-yyyy";

    public InputdDateHourFormat: string = "dd-MMM-yyyy h:m";

    /* Dialog & Confirmation Status*/
    public DialogTitle: string;
    public LabelTitle: string;
    public IsNew: boolean;
    public OpenDialogStatus: boolean;
    public OpenDialogStatus1: boolean;
    
    public OpenConfirmationStatus: boolean;
    public ErrorMessages: string[];
    public IsLoading: boolean;

    public themepanel: string = MyConstants.ColorTheme;

    public openDialog() {
        this.OpenDialogStatus = true;
    }
    public closeDialog() {
        this.OpenDialogStatus = false;
        this.OpenDialogStatus1 = false;
    }

    public openConfirmation() {
        this.OpenConfirmationStatus = true;
    }

    public closeConfirmation() {
        this.OpenConfirmationStatus = false;
    }


    /* Toaster methods */

    public showSuccess(caption: string, message: string) {
        this.showToasterMessage('success', caption, message);
    }

    public showInfo(caption: string, message: string) {
        this.showToasterMessage('info', caption, message);
    }

    public showWarning(caption: string, message: string) {
        this.showToasterMessage('warnining', caption, message);
    }

    public showError(caption: string, message: string) {
        this.showToasterMessage('error', caption, message);
    }

    public showErrors(caption: string) {
        if (this.ErrorMessages.length == 0) return;

        var errorMessage: string = "";
        for (let message of this.ErrorMessages) {
            errorMessage += message + "<br/>";
        }
        this.showToasterMessage('error', caption, errorMessage);
    }

    private showToasterMessage(type: string, caption: string, message: string) {
        this.toasterService.pop(type, caption, message);
    }

    /*validations*/

    public isValid(): boolean {
        return !(this.ErrorMessages.length > 0);
    }

    public toArryString(numbers: number[]): string {
        return (numbers == undefined || numbers == null) ? undefined : numbers.toString();
    }

    public toStringArray(numbers: string): number[] {
        return (numbers == undefined || numbers == null) ? undefined : numbers.replace(/, +/g, ",").split(",").map(Number);
    }

    protected isStringNullOrEmpty(input: string, errorMessage: string): boolean {
        var result: boolean = (input == undefined || input == null || input.trim() == "" || input == undefined);

        if (result && errorMessage != null) {
            this.ErrorMessages.push(errorMessage);
        }

        return result;
    }

    protected isNullOrEmpty(input: number, errorMessage: string): boolean {
        var result: boolean = (input == undefined || input == 0 || input == null || input == undefined);

        if (result && errorMessage != null) {
            this.ErrorMessages.push(errorMessage);
        }

        return result;
    }

    protected isDateNullOrEmpty(input: Date, errorMessage: string): boolean {
        var result: boolean = (input == undefined || input == null || input == undefined);

        if (result && errorMessage != null) {
            this.ErrorMessages.push(errorMessage);
        }

        return result;
    }

    /*Local Storage Data*/

    public OrganizationId(): number {
        return Number.parseInt(localStorage.getItem('OrganizationId'));
    }

    public SetOrganizationId(organizationId: number): number {
        localStorage.setItem('OrganizationId', organizationId.toString());
        return Number.parseInt(localStorage.getItem('OrganizationId'));
    }

    /*Host Listner */
    @HostListener('document:keydown', ['$event'])
    public handleKeyboardEvent(event: KeyboardEvent) {

        let x = event.keyCode;
        if (x === 27) {
            this.OpenDialogStatus = false;
            this.OpenConfirmationStatus = false;
        }
    }
    /*Host Listner */

    /* Printing */
    printData(printContent: string) {
        debugger;
        //let popupWinindow;
        //popupWinindow = window.open('', 'Print', 'width=600,height=700,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no');
        //popupWinindow.document.open();
        //console.log(printContent);
        ////popupWinindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()">' + printContent + '</html>');
        //popupWinindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body>' + printContent + '</body></html>');
        //popupWinindow.print();
        //popupWinindow.document.close();
        //popupWinindow.close();

        let popupWinindow;
        popupWinindow = window.open('', '_blank', 'width=1000,height=700,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no');
        popupWinindow.document.open();
        popupWinindow.document.write('<html><meta charset="ISO-8859-1"><head></head><body onload="window.print()">' + printContent + '</body></html>');
        popupWinindow.document.close();

    }
    public static Clearcache() {
        var id_token = localStorage.getItem("id_token");
        var token = localStorage.getItem("token");
        var UserId = localStorage.getItem("UserId");
        var EmployeeId = localStorage.getItem("EmployeeId");
        var OrganizationId = localStorage.getItem("OrganizationId");
        localStorage.clear();
        localStorage.setItem("id_token", id_token);
        localStorage.setItem("token", token);
        localStorage.setItem("UserId", UserId);
        localStorage.setItem("EmployeeId", EmployeeId);
        localStorage.setItem("OrganizationId", OrganizationId);
    }
}
