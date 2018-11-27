import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';
import { BaseService } from './base.service';

@Injectable()
export class ScoreService extends BaseService {
    public baseServiceUrl: string;

    constructor(public authHttp: HttpClient,
        public authenticationService: AuthenticationService) {
        super(authHttp, authenticationService);
        this.baseServiceUrl = "/api/ScoreApi/";
    }

    getLatestScoreByUserId(userId: number): Observable<any[]> {
        return this.authHttp.get<any[]>(this.baseServiceUrl + 'GetLatestScoreByUserId/' + userId);
    }

    getNotifications(userId: number): Observable<any[]> {
        return this.authHttp.get<any[]>(this.baseServiceUrl + 'GetNotifications/' + userId);
    }

    getProfileScore(userId: number): Observable<any[]> {
        return this.authHttp.get<any[]>(this.baseServiceUrl + 'GetProfileScore/' + userId);
    }

}
