import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleDirective } from './role.directive';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RoleDirective],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {

  userRole = 'user';

  changeRole(role: string) {
    this.userRole = role;
  }
}