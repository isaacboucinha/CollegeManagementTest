import { Component, Inject, Input } from '@angular/core';
import { Subject } from '../../models/Subject';

@Component({
  selector: 'app-subject-detail',
  templateUrl: './subject-detail.component.html',
  styleUrls: ['./subject-detail.component.css']
})
export class SubjectDetailComponent {
  @Input() public subject: Subject;

  constructor() {

  }
}
