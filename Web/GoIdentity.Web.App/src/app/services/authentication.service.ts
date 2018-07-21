import { throwError as observableThrowError, Observable, pipe } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtModule, JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthenticationService {

    public redirectUrl: string;
    public url = "/api/CommonDataApi/";

    private user: any = {};

    constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {
        this.decodeToken();
    }

    public async refreshToken() {

        if (!this.isLoggedIn()) { return; }

        var dateDifference: number = (this.jwtHelper.getTokenExpirationDate(localStorage.getItem('id_token')).getTime() - new Date().getTime()) / 1000 / 60;

        if (dateDifference < 20) {
            let tokenEndpoint: string = "/api/token/refresh";

            var requestHeaders = new HttpHeaders();
            requestHeaders.append('authorization', "bearer " + this.getToken());
            requestHeaders.append('Content-Type', 'application/json');
            requestHeaders.append('OrganizationId', localStorage.getItem("OrganizationId"));

            var result = await this.http.post(tokenEndpoint, "", { headers: requestHeaders }).toPromise<any>();
            if (typeof result.access_token !== 'undefined') {
                this.store(result);
            }
        }
    }

    public SignIn(username: string, password: string): Observable<any> {
        // Token endpoint & params.  
        debugger;
        let tokenEndpoint: string = "/api/token/generate";

        let model: any = {
            grant_type: "password",
            username: username,
            password: password
        };

        //let body: string = this.encodeParams(model);

        return this.http.post<any>(tokenEndpoint, model).pipe(map(result => {
            if (result != undefined) {
                this.store(result);
            }
        }));
    }

    public SignUp(firstname: string, lastname: string, email: string, mobilenumber: string, password: string): Observable<any> {
        // Token endpoint & params.  
        debugger;
        let tokenEndpoint: string = "/api/UserApi/Register";

        let model: any = {
            AccountType: "Individual",
            FirstName: firstname,
            LastName: lastname,
            EmailId: email,
            MobileNumber: mobilenumber,
            Password: password
        }

        //let body: string = this.encodeParams(model);

        return this.http.post<any>(tokenEndpoint, model).pipe(map(result => {
            if (result != undefined) {
                return true;//this.store(result);
            }
        }));
    }

    public signout(): void {
        this.redirectUrl = null;
        this.remove();
        this.user = {};
    }

    public getUser(): any {
        return this.user;
    }

    public decodeToken(): void {
        //debugger;
        if (localStorage.getItem('id_token') != null && !this.jwtHelper.isTokenExpired(localStorage.getItem('id_token'))) {
            let token: string = localStorage.getItem('id_token');
            this.user = this.jwtHelper.decodeToken(token);
        }
    }

    public isLoggedIn(): boolean {
        return (this.getToken() != null) && (this.getToken().length > 0);
    }

    public getToken(): string {
        //let token: string = localStorage.getItem('id_token');
        //return token;

        if (localStorage.getItem('id_token') != null && !this.jwtHelper.isTokenExpired(localStorage.getItem('id_token'))) {
            let token: string = localStorage.getItem('id_token');
            return token;
        }
        else {
            return "";
        }
    }

    private encodeParams(params: any): string {
        let body: string = "";
        for (let key in params) {
            if (body.length) {
                body += "&";
            }
            body += key + "=";
            body += encodeURIComponent(params[key]);
        }
        return body;
    }

    private store(body: any): void {
        debugger;
        localStorage.setItem('id_token', body.access_token);
        localStorage.setItem('token', body.access_token);

        localStorage.setItem('UserId', body.UserId);
        localStorage.setItem('EmployeeId', body.EmployeeId);

        localStorage.setItem('OrganizationId', body.OrganizationId);
        this.decodeToken();
    }

    private remove(): void {
        localStorage.removeItem('id_token');
        localStorage.removeItem('token');

        localStorage.removeItem('UserId');
        localStorage.removeItem('EmployeeId');

        localStorage.removeItem('OrganizationId');
        localStorage.clear();
    }
}  