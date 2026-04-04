import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-bill-table',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './bill-table.component.html'
})
export class BillTableComponent {

  @Input() items: any[] = [];

  remove(i: number) {
    this.items.splice(i, 1);
  }
}