import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  saveBill(bill: any) {
    const bills = JSON.parse(localStorage.getItem('bills') || '[]');
    bills.push(bill);
    localStorage.setItem('bills', JSON.stringify(bills));
  }

  getBills() {
    return JSON.parse(localStorage.getItem('bills') || '[]');
  }
}