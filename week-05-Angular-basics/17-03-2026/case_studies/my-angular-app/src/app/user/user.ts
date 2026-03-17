import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user',
  imports: [CommonModule],
  templateUrl: './user.html',
  styleUrl: './user.css',
})
export class User {
  users = [
    "Alice",
    "Bob",
    "Charlie",
    "David",
  ];
  user = {
    name: 'Alice', age : 30};
    getGreeting() {
      return 'Welcome, ' + this.user.name ;
}
}
