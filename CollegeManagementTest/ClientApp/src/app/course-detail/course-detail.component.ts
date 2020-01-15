import { Component, Inject, Input } from '@angular/core';
import { Course } from '../../models/Course';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrls: ['./course-detail.component.css']
})
export class CourseDetailComponent {
  @Input() public course: Course;

  constructor() {

  }
}
