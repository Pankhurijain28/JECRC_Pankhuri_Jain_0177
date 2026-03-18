import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {

  students = [
    { name: 'Aman', marks: 85 },
    { name: 'Riya', marks: 45 },
    { name: 'Karan', marks: 72 },
    { name: 'Neha', marks: 30 },
    { name: 'Pooja', marks: 95 }
  ];

  getGrade(marks: number) {
    if (marks >= 90) return 'A';
    if (marks >= 75) return 'B';
    if (marks >= 50) return 'C';
    return 'F';
  }
}