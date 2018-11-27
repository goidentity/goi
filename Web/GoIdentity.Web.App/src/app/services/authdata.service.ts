import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';
import { BaseService } from './base.service';

@Injectable()
export class AuthDataService extends BaseService {
    public baseServiceUrl: string;

    constructor(public authHttp: HttpClient,
        public authenticationService: AuthenticationService) {
        super(authHttp, authenticationService);
        this.baseServiceUrl = "/api/oauth/";
    }

    getAuthUrl(): Observable<any> {
        return this.authHttp.get<any>(this.baseServiceUrl + 'url/');
    }

    
}
