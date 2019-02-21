import { Component, OnInit } from '@angular/core';
import {animate, style, transition, trigger} from '@angular/animations';

declare var $: any;

@Component({
  selector: 'app-wizard',
  templateUrl: './wizard.component.html',
  styleUrls: ['./wizard.component.css'],
  animations: [
    trigger("animationFedInFedOut", [
        transition("* => fadeIn", [
            style({ opacity: 0 }),
            animate(900, style({ opacity: 1 }))
        ])
    ])
  ]
})
export class WizardComponent implements OnInit {
  viewMode = "tab1";
  bindingVar = "";
  dateTime: Date;
  tags: string[] = [ "Cool", "Groovy", "Awesome" ];
  routineActivities = [ "Activity 1", "Activity 2"];
  
  constructor() { }

  ngOnInit() {
  }

  fadeIn() {
    this.bindingVar = "fadeIn";
  }

  fadeOut() {
    this.bindingVar = "fadeOut";
  }

  fedEffect() {
    this.bindingVar == "fadeOut" ? this.fadeIn() : this.fadeOut();
  }

  hide() {
    this.fadeOut();
  }

  nextTab() {
    var tabId = $('.active').next('li').attr("id");
    
    if (tabId === undefined) {
      tabId = "tab1"
    }

    this.viewMode = tabId;
  }

  previousTab() {
    var tabId = $('.active').prev('li').attr("id");
    
    this.viewMode = tabId;
  }
}
