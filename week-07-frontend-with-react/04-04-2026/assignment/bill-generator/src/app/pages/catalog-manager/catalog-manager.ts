import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-catalog-manager',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './catalog-manager.html'
})
export class CatalogManager {

  items: any[] = [];

  addItem() {
    this.items.push({ name: '', price: 0, category: '' });
  }

  delete(i: number) {
    this.items.splice(i, 1);
  }
}