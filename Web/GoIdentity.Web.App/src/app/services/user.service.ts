import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Navigation, User } from "../models/domain/user-entities";
import { AuthenticationService } from './authentication.service';
import { BaseService } from './base.service';

@Injectable()
export class UserService extends BaseService {
    public baseServiceUrl: string;

    constructor(public authHttp: HttpClient,
        public authenticationService: AuthenticationService) {
        super(authHttp, authenticationService);
        this.baseServiceUrl = "/api/UserApi/";
    }

    getNavigationItems(): Observable<Navigation[]> {
        return this.authHttp.get<Navigation[]>(this.baseServiceUrl + 'GetNavigationItems/');
    }

    register(registerViewModel: RegisterViewModel) {
        return this.authHttp.post(this.baseServiceUrl + 'Register', JSON.stringify(registerViewModel));
    }

    getUserProfile(): Observable<User> {
        return this.authHttp.get<User>(this.baseServiceUrl + 'GetUserProfile/');
    }

    updateUserProfile(user: User): Observable<boolean> {
        return this.authHttp.post<boolean>(this.baseServiceUrl + 'UpdateUserProfile/', JSON.stringify(user));
    }

    getUserScores(): Observable<any[]> {
        return this.authHttp.get<any[]>(this.baseServiceUrl + 'GetUserScores/');
    }

    forgotPassword(userName: string): Observable<boolean> {
        return this.authHttp.get<boolean>(this.baseServiceUrl + "ForgotPassword?userName=" + userName);
    }
}

export class RegisterViewModel {
    FirstName: string;
    LastName: string;
    Password: string;
    EmailId: string;
    MobileNumber: string;
}

export class UserProfileViewmodel {
    FirstName: string;
    LastName: string;
    MiddleName: string;
    DisplayName: string;
    DOB: string;
    MobileNumber: string;
    AlternateNumber: string;
    Email: string;
    Website: string;
    Address1: string;
    Address2: string;
    Area: string;
    State: string;
    City: string;
    Zip: string;
    Gender: string;
    Profession: string;
    Company: string;
    RolesPlayed: string;
    RolesInterested: string;
    UserId: string;
}

