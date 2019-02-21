import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-planner',
  templateUrl: './planner.component.html',
  styleUrls: ['./planner.component.css']
})
export class PlannerComponent implements OnInit {
  emptyPlan = true;

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
  }

  goToWizard() {
    this.router.navigate(['dashboard/planner/wizard']);
    this.emptyPlan = false;
  }
}
