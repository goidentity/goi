import { Injectable, Injector } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpEventType, HttpHeaders, HttpErrorResponse, HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { AuthenticationService } from './authentication.service';
import { Broadcaster, MessageEvent } from '../models/utilities/broadcaster';

import { JwtHelperService } from '@auth0/angular-jwt';

export class AuthInterceptor implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<HttpEventType.Response>> {
        //debugger;
        var bearerToken = localStorage.getItem('id_token') == null ? "" : localStorage.getItem('id_token');
        var organizationId = localStorage.getItem("OrganizationId") == null ? "0" : localStorage.getItem("OrganizationId");
        var deviceId = localStorage.getItem("deviceId") == null ? "" : localStorage.getItem("deviceId");
        var device = localStorage.getItem("device") == null ? "" : localStorage.getItem("device");

        var authReq: any;
        //debugger;
        if (req.url === "/api/CommonDataApi/UploadFile") {
            authReq = req.clone({
                headers: req.headers
                    .set('Authorization', "bearer " + bearerToken)
                    .set('OrganizationId', organizationId)
                    .set('TimezoneOffset', new Date().getTimezoneOffset().toString())
                    .set('DeviceId', deviceId)
                    .set('Device', device)
            });
        } else if (req.url.indexOf("api/CommonDataApi/DownloadReport") > -1) {
            authReq = req.clone({
                headers: req.headers
                    .set('Authorization', "bearer " + bearerToken)
                    .set('OrganizationId', organizationId)
                    .set('TimezoneOffset', new Date().getTimezoneOffset().toString())
                    .set('DeviceId', deviceId)
                    .set('Device', device)
            });
            authReq.responseType = 'blob';
            //.set('Content-Type', "application/vnd.ms-excel")
        } else {
            authReq = req.clone({
                headers: req.headers
                    .set('Authorization', "bearer " + bearerToken)
                    .set('Content-Type', "application/json")
                    .set('OrganizationId', organizationId)
                    .set('TimezoneOffset', new Date().getTimezoneOffset().toString())
                    .set('DeviceId', deviceId)
                    .set('Device', device)
            });
        }

        return next.handle(authReq).pipe(tap(event => { }, err => {

            if (err instanceof HttpErrorResponse) {
                //debugger;
                if (err.status == 401) {
                    localStorage.clear();
                    window.location.href = "/#/settings/login";
                } else if (err.status == 500 || err.status == 502) {
                    console.error(err.message);
                }
            }

        }));
    }

}