
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpEventType, HttpHeaders, HttpClient } from '@angular/common/http';



import { AuthenticationService } from './authentication.service';

@Injectable()
export class BaseService {
    public baseServiceUrl: string;

    constructor(public authHttp: HttpClient, public authenticationService: AuthenticationService) {
    }

    public getRequestOptions(): HttpHeaders {
        var result = new HttpHeaders();
        result.append('authorization', "bearer " + this.authenticationService.getToken());
        result.append('Content-Type', 'application/json');
        result.append('OrganizationId', localStorage.getItem("OrganizationId"));
        return result;
    }

    public handleError(error: Response) {
        console.error(error);
        return observableThrowError(error.json() || 'Server error');
    }
}

