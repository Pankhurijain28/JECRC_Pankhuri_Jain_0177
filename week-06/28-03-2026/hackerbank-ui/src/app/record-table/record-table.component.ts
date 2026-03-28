import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TransactionService, Transaction } from '../transaction.service';

@Component({
  selector: 'app-record-table',
  standalone: true,
  imports: [CommonModule, FormsModule], // ✅ FIX ngFor + ngModel
  templateUrl: './record-table.component.html',
  styleUrls: ['./record-table.css'],
})
export class RecordTableComponent implements OnInit {

  transactions: Transaction[] = [];
  filteredTransactions: Transaction[] = [];
  selectedDate: string = '';

  constructor(private service: TransactionService) {}

  ngOnInit(): void {
  this.service.getTransactions().subscribe({
    next: (data: Transaction[]) => {
      console.log("DATA FROM API:", data);
      this.transactions = data;
      this.filteredTransactions = data;
    },
    error: (err: any) => {
      console.error("API ERROR:", err);
    }
  });
}

  filterByDate() {
    if (!this.selectedDate) return;

    this.filteredTransactions = this.transactions.filter(t =>
      t.date.split('T')[0] === this.selectedDate
    );
  }

  sortByAmount() {
    this.filteredTransactions = [...this.filteredTransactions].sort(
      (a, b) => a.amount - b.amount
    );
  }
  reset() {
  this.filteredTransactions = this.transactions;
  this.selectedDate = '';
}
}