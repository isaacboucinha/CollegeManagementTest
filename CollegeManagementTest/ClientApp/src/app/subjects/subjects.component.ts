import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Subject } from '../../models/Subject';

@Component({
  selector: 'app-subject',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.css']
})
export class SubjectsComponent {
  public subjects: Subject[];
  public selectedSubject: Subject;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Subject[]>(baseUrl + 'api/Subjects').subscribe(result => {
      this.subjects = result;
    }, error => console.error(error));
  }

  onSelect(subject: Subject) {
    this.selectedSubject = subject;
  }
}
