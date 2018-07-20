import { Component } from '@angular/core';
import {
    Router,
    // import as RouterEvent to avoid confusion with the DOM Event
    Event as RouterEvent,
    NavigationStart,
    NavigationEnd,
    NavigationCancel,
    NavigationError
} from '@angular/router'
import { Broadcaster, MessageEvent } from './models/utilities/broadcaster';
import { Idle, DEFAULT_INTERRUPTSOURCES } from '@ng-idle/core';
import { Keepalive } from '@ng-idle/keepalive';

@Component({
    selector: 'app-root',
    providers: [
        Broadcaster, MessageEvent
    ],
    template: `
       
<div class="ng-busy" *ngIf="loading">
    <div class="ng-busy-default-wrapper">
        <div class="ng-busy-default-sign">
            <div class="ng-busy-default-spinner">
            <div class="bar1"></div>
            <div class="bar2"></div>
            <div class="bar3"></div>
            <div class="bar4"></div>
            <div class="bar5"></div>
            <div class="bar6"></div>
            <div class="bar7"></div>
            <div class="bar8"></div>
            <div class="bar9"></div>
            <div class="bar10"></div>
            <div class="bar11"></div>
            <div class="bar12"></div>
        </div>
        <div class="ng-busy-default-text">Please wait...</div>
        </div>
    </div>
    <div class="ng-busy-backdrop"></div>
</div>

        <router-outlet></router-outlet>`
})
export class AppComponent {

    // Sets initial value to true to show loading spinner on first load
    loading: boolean = true;

    constructor(private idle: Idle,
        private keepalive: Keepalive,
        private router: Router) {
        router.events.subscribe((event: RouterEvent) => {
            this.navigationInterceptor(event);
        });

        idle.setIdle(120);
        idle.setTimeout(1800);
        idle.setInterrupts(DEFAULT_INTERRUPTSOURCES);

        idle.onTimeoutWarning.subscribe((countdown: number) => {
            //alert('Timeout Warning - ' + countdown);
        });

        idle.onTimeout.subscribe(() => {
            localStorage.clear();
            this.router.navigate(['/settings/login']);
        });

        idle.watch();
    }

    // Shows and hides the loading spinner during RouterEvent changes
    navigationInterceptor(event: RouterEvent): void {
        //debugger;
        if (event instanceof NavigationStart) {
            this.loading = true;
        }
        if (event instanceof NavigationEnd) {
            this.loading = false;
        }

        // Set loading state to false in both of the below events to hide the spinner in case a request fails
        if (event instanceof NavigationCancel) {
            this.loading = false;
        }
        if (event instanceof NavigationError) {
            this.loading = false;
        }
    }

}
