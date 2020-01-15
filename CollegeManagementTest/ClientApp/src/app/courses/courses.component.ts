import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Course } from '../../models/Course';

@Component({
  selector: 'app-course',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent {
  public courses: Course[];
  public selectedCourse: Course;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Course[]>(baseUrl + 'api/Courses').subscribe(result => {
      this.courses = result;
    }, error => console.error(error));
  }

  onSelect(course: Course) {
    this.selectedCourse = course;
  }
}
