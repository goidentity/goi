import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { JwtModule, JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticationService } from '../services/authentication.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(public authenticationService: AuthenticationService, private router: Router, private jwtHelper: JwtHelperService) { }
    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

        try {
            if (!this.jwtHelper.isTokenExpired(this.authenticationService.getToken())) {
                // Signed in.  
                return true;
            }
        } catch (e) {
            console.log(e);
            localStorage.clear();
            this.router.navigate(['/settings/login']);
            return false;
        }

        let url: string = state.url;
        this.authenticationService.redirectUrl = url;

        this.router.navigate(['/settings/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }

}  