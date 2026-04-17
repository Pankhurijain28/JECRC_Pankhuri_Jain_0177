import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import jsPDF from 'jspdf';

import { CatalogSelectorComponent } from '../../components/catalog-selector/catalog-selector.component';
import { BillTableComponent } from '../../components/bill-table/bill-table.component';
import { StorageService } from '../../services/storage.service';

@Component({
  selector: 'app-bill-generator',
  standalone: true,
  imports: [CommonModule, FormsModule, CatalogSelectorComponent, BillTableComponent],
  templateUrl: './bill-generator.component.html',
  styleUrls: ['./bill-generator.css']
})
export class BillGeneratorComponent {

  items: any[] = [];
  discount = 0;
  discountType: 'amount' | 'percent' = 'amount';

  customName = '';
  customPrice = 0;
  donationAmount = 0;

  constructor(private storage: StorageService) {}

  addItem(item: any) {
    this.items.push(item);
  }

  addCustom() {
    this.items.push({ name: this.customName, price: this.customPrice, qty: 1, category: 'Custom' });
    this.customName = '';
    this.customPrice = 0;
  }

  addDonation() {
    this.items.push({ name: 'Donation', price: this.donationAmount, qty: 1, category: 'Donation' });
    this.donationAmount = 0;
  }

  get subtotal() {
    return this.items.reduce((s, i) => s + i.price * i.qty, 0);
  }

  get tax() {
    return this.subtotal * 0.18;
  }

  get discountValue() {
    return this.discountType === 'percent'
      ? this.subtotal * (this.discount / 100)
      : this.discount;
  }

  get total() {
    return this.subtotal + this.tax - this.discountValue;
  }

  generateInvoice() {

    const bill = {
      items: this.items,
      total: this.total,
      date: new Date()
    };

    this.storage.saveBill(bill);

    const pdf = new jsPDF();

    pdf.text("SmartBill Pro", 80, 10);

    let y = 20;

    this.items.forEach(i => {
      pdf.text(`${i.name} x${i.qty} = ₹${i.price * i.qty}`, 10, y);
      y += 10;
    });

    pdf.text(`Total: ₹${this.total}`, 10, y + 10);

    pdf.save('invoice.pdf');
  }
}