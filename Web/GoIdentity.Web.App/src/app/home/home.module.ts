import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';

import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { SortableModule } from '@progress/kendo-angular-sortable';
import { GridModule } from '@progress/kendo-angular-grid';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RippleModule } from '@progress/kendo-angular-ripple';

import { DndModule } from 'ngx-dnd';
import { TreeviewModule, TreeviewI18n } from 'ngx-treeview';
import { ToasterModule, ToasterService } from 'angular2-toaster';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { MentionModule } from 'angular-mentions/mention';
import { DashboardComponent } from './dashboard.component';
import { HomeRoutingModule } from './home-routing.module';
import { AuthInterceptor } from '../services/auth.interceptor';

@NgModule({
    imports: [
        CommonModule,
        DndModule.forRoot(),
        BsDropdownModule.forRoot(),
        HttpClientModule,
        FormsModule,
        TabsModule,
        ReactiveFormsModule,
        ButtonsModule,
        DateInputsModule,
        InputsModule,
        DialogModule,
        GridModule,
        DropDownsModule,
        TreeviewModule.forRoot(),
        ToasterModule,
        SortableModule,
        MentionModule,
        ChartsModule,
        HomeRoutingModule, RippleModule
    ],
    declarations: [DashboardComponent
    ],
    providers: [ToasterService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        }]
})
export class HomeModule { }
