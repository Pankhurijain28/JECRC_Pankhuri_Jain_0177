import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CatalogSelectorComponent } from '../../components/catalog-selector/catalog-selector.component';
import { BillTableComponent } from '../../components/bill-table/bill-table.component';
import { InvoicePreviewComponent } from '../../components/invoice-preview/invoice-preview.component';

@Component({
  selector: 'app-bill-generator',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    CatalogSelectorComponent,
    BillTableComponent,
    InvoicePreviewComponent
  ],
  templateUrl: './bill-generator.component.html',
  styleUrls: ['./bill-generator.css']
})
export class BillGeneratorComponent {

  items: any[] = [];
  discount = 0;
  showInvoice = false;

  addItem(item: any) {
    this.items.push(item);
  }

  get subtotal() {
    return this.items.reduce((s, i) => s + i.price * i.qty, 0);
  }

  get tax() {
    return this.subtotal * 0.18;
  }

  get total() {
    return this.subtotal + this.tax - this.discount;
  }

  generateInvoice() {
    this.showInvoice = true;
  }
}