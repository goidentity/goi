//import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core'
//import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { BaseService } from './base.service';
import { AuthenticationService } from './authentication.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Navigation, UserProfile } from "../models/domain/user-entities";
import { ChangePassword, Client } from '../models/domain/user-entities';

import { AccessControl, vAccessControl } from '../models/domain/accesscontrol-entities';
import { Role, MapUserRole, vMapUserRole } from '../models/domain/role-entities';

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
    
    getUserProfile(): Observable<UserProfile> {
        return this.authHttp.get<UserProfile>(this.baseServiceUrl + 'GetUserProfile/');
    }

    //createUserProfile(userProfileViewmodel: UserProfileViewmodel) {
    //    return this.authHttp.post(this.baseServiceUrl + 'CreateUserProfile', JSON.stringify(userProfileViewmodel));
    //}
    public createUserProfile(firstname: string, lastname: string, middlename: string, displayname: string, dob: string, mobilenumber: string, alternatenumber: string, email: string, address1: string): Observable<any> {
        let tokenEndpoint: string = "/api/UserApi/CreateUserProfile";
        let model: any = {
            FirstName: firstname,
            LastName: lastname,
            MiddleName: middlename,
            DisplayName: displayname,
            DOB: dob,
            MobileNumber: mobilenumber,
            AlternateNumber: alternatenumber,
            Email: email,
            Address1: address1,
            Address2: firstname,
            Area: lastname,
            State: lastname,
            City: lastname,
            Zip: lastname,
            Gender: lastname,
            Profession: lastname,
            Company: lastname,
            RolesPlayed: lastname,
            RolesInterested: lastname,
            UserId: lastname
        }
        return this.authHttp.post<any>(tokenEndpoint, model).pipe(map(result => {
            if (result != undefined) {
                return result;
            }
        }));
    }

    updateUserProfile(userProfileViewmodel: UserProfileViewmodel) {
        return this.authHttp.post(this.baseServiceUrl + 'UpdateUserProfile', JSON.stringify(userProfileViewmodel));
    }

    forgotPassword(userName: string): Observable<boolean> {
        return this.authHttp.get<boolean>(this.baseServiceUrl + "ForgotPassword?userName=" + userName);
    }
}

export class RegisterViewModel
{
    FirstName: string;
    LastName: string;
    Password: string;
    EmailId: string;
    MobileNumber: string;
}

export class UserProfileViewmodel
{
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

