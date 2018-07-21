import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { BaseService } from './base.service';
import { AuthenticationService } from './authentication.service';

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

}

export class RegisterViewModel
{
    FirstName: string;
    LastName: string;
    Password: string;
    EmailId: string;
    MobileNumber: string;
}

