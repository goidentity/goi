import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SettingsRoutes } from "./settings.routing";

import { DropDownsModule, DropDownListComponent, PreventableEvent } from '@progress/kendo-angular-dropdowns';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { aggregateBy } from '@progress/kendo-data-query';
import { GridModule } from '@progress/kendo-angular-grid';
import { RippleModule } from '@progress/kendo-angular-ripple';

import { LoginComponent } from "./login.component";
import { RegisterComponent } from "./register.component";
import { p404Component } from "./404.component";
import { p500Component } from "./500.component";
import { ChangePasswordComponent } from "./changepassword.Component";

import { ToasterModule, ToasterService } from 'angular2-toaster';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AuthInterceptor } from '../services/auth.interceptor';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(SettingsRoutes),
        Ng4LoadingSpinnerModule.forRoot(),
        HttpClientModule,
        FormsModule,
        ToasterModule,
        ButtonsModule,
        DialogModule,
        DropDownsModule,
        DateInputsModule,
        GridModule,
        ReactiveFormsModule,
RippleModule,
        TabsModule
    ],
    declarations: [
        LoginComponent,
        RegisterComponent,
        p500Component,
        p404Component,
        ChangePasswordComponent,
        
    ],
    providers: [ToasterService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        }]
})
export class SettingsModule { }

