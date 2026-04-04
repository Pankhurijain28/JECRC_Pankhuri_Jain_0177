import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CatalogService {

  items = [
    { name: 'Adult Ticket', category: 'Entrance', price: 200 },
    { name: 'Child Ticket', category: 'Entrance', price: 100 },
    { name: 'VIP Ticket', category: 'Entrance', price: 500 },

    { name: 'Donation ₹100', category: 'Donation', price: 100 },
    { name: 'Donation ₹500', category: 'Donation', price: 500 },

    { name: 'Coffee', category: 'Product', price: 150 }
  ];

  getCatalog(category: string) {
    return this.items.filter(i => i.category === category);
  }
}