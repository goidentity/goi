import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from "./login.component";
import { ChangePasswordComponent } from "./changepassword.Component";
import { p500Component } from "./500.component";
import { p404Component } from "./404.component";
import { ForgotPasswordComponent } from "./forgot-password.component";
import { RegisterComponent } from "./register.component";

export const SettingsRoutes: Routes = [
    {
        path: 'login',
        component: LoginComponent
    }, {
        path: 'register',
        component: RegisterComponent
    }, {
        path: 'forgot',
        component: ForgotPasswordComponent
    },
    {
        path: '404',
        component: p404Component
    },
    {
        path: '500',
        component: p500Component
    },
    {
        path: 'changepassword',
        component: ChangePasswordComponent
    },
    {
        path: 'changepassword/:id',
        component: ChangePasswordComponent
    }
    
];

