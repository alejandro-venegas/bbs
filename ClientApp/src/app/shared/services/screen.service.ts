import { Injectable, OnInit } from "@angular/core";
import { BreakpointObserver, Breakpoints } from "@angular/cdk/layout";
import { BehaviorSubject, Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ScreenService {
  screenWidthSubject = new BehaviorSubject<any>(null);

  constructor(private breakpointObserver: BreakpointObserver) {}

  initializeBreakPointsSubject() {
    this.breakpointObserver
      .observe(["(min-width: 1110px)", "(max-width: 600px)"])
      .subscribe((res) => {
        console.log(res);
        this.screenWidthSubject.next(res);
      });
  }
}
