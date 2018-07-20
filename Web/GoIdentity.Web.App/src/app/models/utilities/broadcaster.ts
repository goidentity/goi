
import { map, filter } from 'rxjs/operators';
import { Component, OnInit, HostListener, Input, Injectable } from '@angular/core';
import { Subject, Observable, pipe } from 'rxjs';
import { tap } from "rxjs/internal/operators/tap";

interface BroadcastEvent {
    key: any;
    data?: any;
}

export class Broadcaster {
    private _eventBus: Subject<BroadcastEvent>;

    constructor() {
        this._eventBus = new Subject<BroadcastEvent>();
    }

    public broadcast(key: any, data?: any) {
        this._eventBus.next({ key, data });
    }

    public on<T>(key: any): Observable<T> {
        return this._eventBus.asObservable()
            .filter(event => event.key === key).pipe(map(event => <T>(event as any).data));
    }

}

@Injectable()
export class MessageEvent {
    constructor(private broadcaster: Broadcaster) { }

    public fire(key: string, data: string): void {
        //debugger;
        this.broadcaster.broadcast(key, data);
    }

    public on(key: string): Observable<string> {
        //debugger;
        return this.broadcaster.on<string>(key);
    }
}