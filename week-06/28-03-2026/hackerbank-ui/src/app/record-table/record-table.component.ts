import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TransactionService, Transaction } from '../transaction.service';

@Component({
  selector: 'app-record-table',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './record-table.component.html',
  styleUrls: ['./record-table.css']
})
export class RecordTableComponent implements OnInit {

  transactions: Transaction[] = [];
  filteredTransactions: Transaction[] = [];
  selectedDate: string = '';

  showModal: boolean = false;

  formData: Transaction = {
    id: 0,
    date: '',
    description: '',
    type: 0,
    amount: 0,
    balance: ''
  };

  constructor(private service: TransactionService) {}

  ngOnInit(): void {
    this.loadTransactions();
  }

  loadTransactions() {
    this.service.getTransactions().subscribe({
      next: (data) => {
        this.transactions = data;
        this.filteredTransactions = data;
      },
      error: (err) => console.error(err)
    });
  }

  filterByDate() {
    if (!this.selectedDate) return;

    this.filteredTransactions = this.transactions.filter(t =>
      t.date.split('T')[0] === this.selectedDate
    );
  }

  reset() {
    this.filteredTransactions = this.transactions;
    this.selectedDate = '';
  }

  sortByAmount() {
    this.filteredTransactions = [...this.filteredTransactions].sort(
      (a, b) => a.amount - b.amount
    );
  }

  openModal() {
    this.showModal = true;
  }

  closeModal() {
    this.showModal = false;
  }

  submitTransaction() {
    if (!this.formData.date || !this.formData.description || this.formData.amount <= 0) {
      alert("Fill all fields properly");
      return;
    }

    this.service.addTransaction(this.formData).subscribe({
      next: () => {
        this.loadTransactions();
        this.closeModal();

        this.formData = {
          id: 0,
          date: '',
          description: '',
          type: 0,
          amount: 0,
          balance: ''
        };
      },
      error: (err) => console.error(err)
    });
  }
}