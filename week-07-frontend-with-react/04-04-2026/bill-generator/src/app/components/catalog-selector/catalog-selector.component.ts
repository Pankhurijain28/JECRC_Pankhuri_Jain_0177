import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CatalogService } from '../../services/catalog.service';

@Component({
  selector: 'app-catalog-selector',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './catalog-selector.component.html',
  styleUrls: ['./catalog-selector.component.css']
})
export class CatalogSelectorComponent {

  @Output() selectItem = new EventEmitter<any>();

  activeTab = 'Entrance';
  search = '';

  constructor(public catalogService: CatalogService) {}

  select(item: any) {
    this.selectItem.emit({ ...item, qty: 1 });
  }

  filteredItems() {
    return this.catalogService
      .getCatalog(this.activeTab)
      .filter(i => i.name.toLowerCase().includes(this.search.toLowerCase()));
  }
}