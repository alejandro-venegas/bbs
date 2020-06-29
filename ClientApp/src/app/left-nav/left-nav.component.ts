import { Component, EventEmitter, OnInit, Output } from "@angular/core";

@Component({
  selector: "app-left-nav",
  templateUrl: "./left-nav.component.html",
  styleUrls: ["./left-nav.component.css"],
})
export class LeftNavComponent implements OnInit {
  @Output() toggleNav = new EventEmitter();
  constructor() {}

  ngOnInit(): void {}

  onLogoClick() {
    this.toggleNav.emit();
  }
}
