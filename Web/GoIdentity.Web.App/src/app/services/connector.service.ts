﻿import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';
import { BaseService } from './base.service';

@Injectable()
export class ConnectorService extends BaseService {
    public baseServiceUrl: string;

    constructor(public authHttp: HttpClient,
        public authenticationService: AuthenticationService) {
        super(authHttp, authenticationService);
        this.baseServiceUrl = "/api/oauth/";
    }
    connectFacebook(): Observable<any> {
        return this.authHttp.get<any>(this.baseServiceUrl + "facebook/");
    }
    connectLinkedIn(): Observable<any> {
        return this.authHttp.get<any>(this.baseServiceUrl + "linkedin/");
    }
    connectTwitter(): Observable<any> {
        return this.authHttp.get<any>(this.baseServiceUrl + "twitter/");
    }
    connectGooglePlus(): Observable<any> {
        return this.authHttp.get<any>(this.baseServiceUrl + "googleplus/");
    }
    connectInstagram(): Observable<any> {
        return this.authHttp.get<any>(this.baseServiceUrl + "instagram/");
    }
    connectPinterest(): Observable<any> {
        return this.authHttp.get<any>(this.baseServiceUrl + "pinterest/");
    }
}