import { Component, OnInit, HostListener, Input, ElementRef, OnDestroy, AfterViewInit } from '@angular/core';
import { DialogModule } from '@progress/kendo-angular-dialog';

import { GridModule } from '@progress/kendo-angular-grid';
import { BaseComponent } from '../shared/base-component';
import { Navigation, UserProfile } from "../models/domain/user-entities";
import { Router, NavigationEnd } from '@angular/router';

import { ToasterService } from 'angular2-toaster/angular2-toaster';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';
import { Guid, InputDataTypeConstants, InputControlTypeConstants, InputSourceTypeConstants, KeyConstants } from '../models/utilities/Guid';

import { Organization, vMapOrganization } from '../models/domain/user-entities';
import { ChangePassword, Client } from '../models/domain/user-entities';

import { MyConstants } from '../models/domain/my-constants';
import { GlobalVariables } from '../models/utilities/handy-entities';


@Component({
    selector: 'app-dashboard',
    templateUrl: './full-layout.component.html',
    styles: ['.my-class { background- color: yellow;}'],

    providers: [ToasterService, AuthenticationService, UserService, MessageEvent]
})
export class FullLayoutComponent extends BaseComponent implements OnInit, AfterViewInit {

    public userProfile: UserProfile;
    public organizations: Organization[] = [];

    public logedinOrganztion: string;
    public loggedInUser: string;
    public client: Client;
    public scrollLister = false;
    public preventScroll = false;
    constructor(
        public toasterService: ToasterService,
        public authenticationService: AuthenticationService,
        public userService: UserService,
        public messageEvent: MessageEvent,
        public elementref: ElementRef,
        private router: Router
    ) {
        super(toasterService, authenticationService, messageEvent);

        this.messageEvent.on(KeyConstants.BreadcrumbsTitle).subscribe(message => {
            this.scrollLister = false;
            this.breadcrumbsTitle = message;

            if (this.modulesList == undefined) {
                this.userService.getNavigationItems()
                    .subscribe(nl => {
                        debugger;
                        this.modulesList = nl;
                        this.loadSideMenu();
                    });
            } else {
                this.loadSideMenu();
            }

        });
        
    }

    ngAfterViewInit(): void {
        this.messageEvent.fire(KeyConstants.BreadcrumbsTitle, "");
    }

    private loadSideMenu() {
        debugger;
        var currentIndex: boolean = false;
        var currentNavigationId = 0;
        for (var i = 0; i < this.modulesList.length; i++) {
            for (var j = 0; j < this.modulesList[i].ChildItems.length; j++) {
                for (var k = 0; k < this.modulesList[i].ChildItems[j].ChildItems.length; k++) {
                    if (this.modulesList[i].ChildItems[j].ChildItems[k].NavigationPath == this.router.url) {
                        currentNavigationId = this.modulesList[i].NavigationId;
                        currentIndex = true;
                        break;
                    }
                }
                if (currentIndex == true)
                    break;
            }
            if (currentIndex == true)
                break;
        }
        if (currentNavigationId > 0) { this.onModuleClick(currentNavigationId); }
        else { this.onModuleClick(this.modulesList[0].NavigationId); }
    }

    public status: { isopen: boolean } = { isopen: false };

    public onHidden(): void {
        //console.log('Dropdown is hidden');
    }
    public onShown(): void {
        //console.log('Dropdown is shown');
    }
    public isOpenChange(): void {
        //console.log('Dropdown state is changed');
    }

    /* Variables  */
    public changeOranizaion: Organization[];

    public modulesList: Navigation[];
    public navigationItemsList: Navigation[];

    public breadcrumbsTitle: string = "";
    returnUrl: string;
    errorMsg: string;

    ngOnInit(): void {
        if (!this.authenticationService.isLoggedIn()) {
            this.authenticationService.signout();
            this.setColour("#499f50", 0);
            window.location.href = "/#/settings/login";
            return null;
            //document.location.reload(true);
            //this.router.navigate(['/settings/login']);

        }

        
    }

    public openModules() {
        this.OpenDialogStatus = true;
        
    }

    public toggled(open: boolean): void {
        //console.log('Dropdown is now: ', open);
    }

    getNavigationTitle(title: string) {
        GlobalVariables.PageTitle = title;
        this.breadcrumbsTitle = title;
    }

    public toggleDropdown($event: MouseEvent): void {
        $event.preventDefault();
        $event.stopPropagation();
        this.status.isopen = !this.status.isopen;
    }

    onModuleClick(navigationId: number) {
        debugger;
        var selectedGuid: string = "";

        this.navigationItemsList = this.modulesList.filter(f => f.NavigationId == navigationId);
        if (this.navigationItemsList.length > 0) {
            selectedGuid = this.navigationItemsList[0].NavigationUid.toUpperCase();
        }

        document.querySelector('body').classList.add('sidebar-mobile-show');
    }

    onSignout(): void {

        this.authenticationService.signout();
        this.setColour("#499f50", 0);
        //document.location.reload(true);
        this.router.navigate(['/settings/login']);
    }

    onSettingClick() {
    }

    public onChangeOrganization() {
        this.OpenDialogStatus = true;
    }
    highlightedDiv: number;

    toggleHighlight(newValue: number) {
        if (this.highlightedDiv === newValue) {
            this.highlightedDiv = 0;
        }
        else {
            this.highlightedDiv = newValue;
        }
    }


    //Theme  Panel

    public colorSet: Array<string> = ["#499f50", "#003056"]
    public SideBarColor: Array<string> = ["#ededed", "#003c6c"]
    public SideBarColortxt: Array<string> = ["black", "white"]
    public ColorPanel: Array<string> = ["darkGreentheme", "darkBluetheme"]


    public color: any;
    public color1: any;
    public colortxt: any;
    public themepanel: any;

    public setColour(item: string, index: number) {
        this.color = item;
        this.colortxt = this.SideBarColortxt[index];
        this.themepanel = this.ColorPanel[index];
        MyConstants.ColorTheme = this.themepanel;
        this.color1 = this.SideBarColor[index];
    }

    // Set Module Colors
    public moduleColorSet: Array<string> = ["#228e42", "#2d6398", "#f07f20", "#ff4350"]
    public colors: Array<string>;
    public preparecolor() {
        this.colors = Array<string>();
        var count = 0;
        for (let item of this.modulesList) {
            this.colors.push(this.moduleColorSet[count]);
            count = count + 1;
            if (this.moduleColorSet.length == count)
                count = 0;
        }
    }

    onSwitchOrganization(organization: vMapOrganization) {
        BaseComponent.Clearcache();
        localStorage.setItem('OrganizationId', organization.OrganizationId.toString());
        //this.loggedInUser = organization.UserName;
        this.logedinOrganztion = organization.Title.toString();
        this.OpenDialogStatus = false;
        this.returnUrl = '/';
        this.router.navigate([this.returnUrl]);
    }
    @HostListener("scroll", ['$event'])
    onWindowScroll(event: any) {
        let gridHeader = document.querySelector(".k-grid-header");
        let gridContent = document.querySelector(".k-grid-content");
        let header = document.querySelector("header");
        let main = document.querySelector(".main");
        let grid = document.querySelector("kendo-grid");
        let wrap = document.querySelector(".k-grid-header-wrap");
        let top = (gridHeader != null ? gridHeader.getBoundingClientRect().top : 0) - (header != null ? header.getBoundingClientRect().height : 0);
        if (gridContent != null) {
            if (top <= 0) {
                this.preventScroll = false;
                (gridHeader as HTMLInputElement).classList.add("fixedHeader");

                (wrap as HTMLInputElement).classList.add("initialHeader");
                if (!this.scrollLister) {
                    this.scrollLister = true;
                    main.addEventListener('scroll', this.onContentScroll.bind(this), false);
                }
            }
        }
    }
    onContentScroll(event: any) {
        let main = document.querySelector(".main");
        let gridHeader = document.querySelector(".k-grid-header");
        if (this.preventScroll == false && gridHeader != null) {
            if (main.scrollTop <= 0) {
                main.removeEventListener('scroll', this.onContentScroll.bind(this), false);
                (gridHeader as HTMLInputElement).classList.remove("fixedHeader");
                let wrap = document.querySelector(".k-grid-header-wrap");
                (wrap as HTMLInputElement).classList.remove("initialHeader");
                this.preventScroll = true;
            }
            gridHeader.scrollTo(event.target.scrollLeft, 0);
        }
    }
}
