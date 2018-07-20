import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: '<router-outlet></router-outlet>',
  styles: [' app-dashboard { position: relative;overflow: scroll;}'],
  providers: []

})
export class SimpleLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void { }
}
