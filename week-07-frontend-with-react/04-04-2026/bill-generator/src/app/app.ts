import { Component } from '@angular/core';
import { BillGeneratorComponent } from './pages/bill-generator/bill-generator.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [BillGeneratorComponent],
  templateUrl: './app.component.html'
})
export class AppComponent {}