import { NgModule } from '@angular/core';
import {
    Routes,
    RouterModule,
    // import as RouterEvent to avoid confusion with the DOM Event
    Router,
    Event as RouterEvent,
    NavigationStart,
    NavigationEnd,
    NavigationCancel,
    NavigationError
} from '@angular/router';

import { FullLayoutComponent } from './layouts/full-layout.component';
import { SimpleLayoutComponent } from './layouts/simple-layout.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
    },
    {
        path: '',
        component: FullLayoutComponent,
        data: {
            title: 'Home'
        },
        children: [
            {
                path: 'home',
                loadChildren: './home/home.module#HomeModule'
            },
            {
                path: 'ops',
                loadChildren: './ops/ops.module#OpsModule'
            }
        ]
    },
    {
        path: '',
        component: SimpleLayoutComponent,
        children: [
            {
                path: 'settings',
                loadChildren: './settings/settings.module#SettingsModule',
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
