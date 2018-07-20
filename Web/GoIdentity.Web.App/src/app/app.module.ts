import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { GridModule } from '@progress/kendo-angular-grid';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { RippleModule } from '@progress/kendo-angular-ripple';
import { NAV_DROPDOWN_DIRECTIVES } from './shared/nav-dropdown.directive';
import { BsDropdownModule, AccordionModule } from 'ngx-bootstrap';
import { SIDEBAR_TOGGLE_DIRECTIVES } from './shared/sidebar.directive';
import { AsideToggleDirective } from './shared/aside.directive';
import { BreadcrumbsComponent } from './shared/breadcrumb.component';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';

// Routing Module
import { AppRoutingModule } from './app.routing';
import { AppComponent } from './app.component';
import { CustomErrorHandler } from './shared/custom-errorHandler';

//Layouts
import { FullLayoutComponent } from './layouts/full-layout.component';
import { SimpleLayoutComponent } from './layouts/simple-layout.component';

import { AuthGuard } from './services/authguard.service';
import { AuthenticationService } from './services/authentication.service'
//import { SpinnerComponentModule } from 'ng2-component-spinner';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { SortableModule } from '@progress/kendo-angular-sortable';
//Loading
import { Broadcaster, MessageEvent } from './models/utilities/broadcaster';
import { SettingsModule } from './settings/settings.module';
import { AuthInterceptor } from './services/auth.interceptor';
import { JwtModule, JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';
//import { NgIdleKeepaliveModule } from '@ng-idle/keepalive';
import { DeviceDetectorModule } from 'ngx-device-detector';
import { NgIdleKeepaliveModule } from '@ng-idle/keepalive';

export function getToken() {
    return localStorage.getItem('id_token');
}

@NgModule({
    imports: [
        BsDropdownModule.forRoot(),
        BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        HttpClientModule,
        TabsModule.forRoot(),
        AccordionModule.forRoot(),
        Ng4LoadingSpinnerModule.forRoot(),
        //SpinnerComponentModule,
        SortableModule,
        DialogModule,
        RippleModule,
        GridModule,
        SettingsModule,
        //NgIdleKeepaliveModule.forRoot(),
        JwtModule.forRoot({
            config: {
                tokenGetter: getToken
            }
        }),
        DeviceDetectorModule.forRoot(),
        NgIdleKeepaliveModule.forRoot()
    ],
    declarations: [
        AppComponent,
        FullLayoutComponent,
        NAV_DROPDOWN_DIRECTIVES,
        BreadcrumbsComponent,
        SIDEBAR_TOGGLE_DIRECTIVES,
        AsideToggleDirective,
        SimpleLayoutComponent
    ],
    providers: [AuthGuard,
        JwtHelperService,
        AuthenticationService,
        {
            provide: LocationStrategy,
            useClass: HashLocationStrategy,
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        },
        {
            provide: ErrorHandler,
            useClass: CustomErrorHandler
        }],
    bootstrap: [AppComponent]
})
export class AppModule {

}
