import { Component } from '@angular/core';
import { BillGeneratorComponent } from './pages/bill-generator/bill-generator.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [BillGeneratorComponent],
  template: `<app-bill-generator></app-bill-generator>`
})
export class AppComponent {}