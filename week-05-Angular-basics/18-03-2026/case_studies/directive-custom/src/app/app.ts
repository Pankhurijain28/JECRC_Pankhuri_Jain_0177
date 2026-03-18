import { Component, signal } from '@angular/core';
import { HighlightDirective } from './highlight.directive'; 

@Component({
  selector: 'app-root',
  standalone: true, 
  imports: [HighlightDirective],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('directive-custom');
}