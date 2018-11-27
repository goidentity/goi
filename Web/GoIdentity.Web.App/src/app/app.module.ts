import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { NgIdleKeepaliveModule } from '@ng-idle/keepalive';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { GridModule } from '@progress/kendo-angular-grid';
import { RippleModule } from '@progress/kendo-angular-ripple';
import { SortableModule } from '@progress/kendo-angular-sortable';
//import { SpinnerComponentModule } from 'ng2-component-spinner';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { AccordionModule, BsDropdownModule } from 'ngx-bootstrap';
import { TabsModule } from 'ngx-bootstrap/tabs';
//import { NgIdleKeepaliveModule } from '@ng-idle/keepalive';
import { DeviceDetectorModule } from 'ngx-device-detector';
import { AppComponent } from './app.component';
// Routing Module
import { AppRoutingModule } from './app.routing';
//Layouts
import { FullLayoutComponent } from './layouts/full-layout.component';
import { SimpleLayoutComponent } from './layouts/simple-layout.component';
import { AuthInterceptor } from './services/auth.interceptor';
import { AuthenticationService } from './services/authentication.service';
import { AuthGuard } from './services/authguard.service';
import { SettingsModule } from './settings/settings.module';
import { AsideToggleDirective } from './shared/aside.directive';
import { BreadcrumbsComponent } from './shared/breadcrumb.component';
import { CustomErrorHandler } from './shared/custom-errorHandler';
import { NAV_DROPDOWN_DIRECTIVES } from './shared/nav-dropdown.directive';
import { SIDEBAR_TOGGLE_DIRECTIVES } from './shared/sidebar.directive';

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
