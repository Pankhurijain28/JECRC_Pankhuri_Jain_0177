import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClickBlockDirective } from './click-block';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ClickBlockDirective],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {

  isAllowed = false;

  togglePermission() {
    this.isAllowed = !this.isAllowed;
  }

  performAction() {
    alert(' Action executed successfully!');
  }
}