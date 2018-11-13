import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../services/authguard.service';

import { DashboardComponent } from './dashboard.component';
import { MyidentityComponent } from './myidentity.component';
import { MyprofileComponent } from './myprofile.component';
import { NotificationsComponent } from './notifications.component';
import { AboutComponent } from './about.component';
import { ContactusComponent } from './contactus.component';
import { ConnectorComponent } from './connector.component';
import { ProfileComponent } from './profile.component';

const routes: Routes = [
    {
        path: 'home',
        redirectTo: 'dashboard'
    }, {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [AuthGuard],
        data: {
            title: 'Dashboard'
        }
    }, {
        path: 'myidentity',
        component: MyidentityComponent,
        canActivate: [AuthGuard],
        data: {
            title: 'myidentity'
        }
    }, {
        path: 'myprofile',
        component: MyprofileComponent,
        canActivate: [AuthGuard],
        data: {
            title: 'myprofile'
        }
    }, {
        path: 'notifications',
        component: NotificationsComponent,
        canActivate: [AuthGuard],
        data: {
            title: 'notifications'
        }
    }, {
        path: 'about',
        component: AboutComponent,
        canActivate: [AuthGuard],
        data: {
            title: 'about'
        }
    }, {
        path: 'contactus',
        component: ContactusComponent,
        canActivate: [AuthGuard],
        data: {
            title: 'contactus'
        }

    }, {
        path: 'connectors',
        component: ConnectorComponent,
        canActivate: [AuthGuard],
        data: {
            title: 'connectors'
        }
    }  ,{
        path: 'profile',
        component: ProfileComponent,
        canActivate: [AuthGuard],
        data: {
            title: 'Self Profile'
        }
    
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class OpsRoutingModule { }
