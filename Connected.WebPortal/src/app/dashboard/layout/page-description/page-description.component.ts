import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-description',
  templateUrl: './page-description.component.html',
  styleUrls: ['./page-description.component.css']
})
export class PageDescriptionComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

}
