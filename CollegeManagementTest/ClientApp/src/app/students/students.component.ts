import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Student } from '../../models/Student';

@Component({
  selector: 'app-student',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent {
  public students: Student[];
  public selectedStudent: Student;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Student[]>(baseUrl + 'api/Students').subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }

  onSelect(student: Student) {
    this.selectedStudent = student;
  }
}
