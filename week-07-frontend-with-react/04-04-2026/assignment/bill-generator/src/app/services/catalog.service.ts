import { Injectable } from '@angular/core';
import { Item } from '../models/item.model';

@Injectable({ providedIn: 'root' })
export class CatalogService {

  items: Item[] = [

    { name: 'Adult Ticket', category: 'Entrance', price: 200, qty: 1, image: 'https://cdn-icons-png.flaticon.com/512/1046/1046784.png' },
    { name: 'Child Ticket', category: 'Entrance', price: 100, qty: 1, image: 'https://cdn-icons-png.flaticon.com/512/1046/1046784.png' },

    { name: 'Burger', category: 'Food', price: 150, qty: 1, image: 'https://cdn-icons-png.flaticon.com/512/3075/3075977.png' },
    { name: 'Pizza', category: 'Food', price: 300, qty: 1, image: 'https://cdn-icons-png.flaticon.com/512/3132/3132693.png' },

    { name: 'Parking', category: 'Service', price: 50, qty: 1, image: 'https://cdn-icons-png.flaticon.com/512/684/684908.png' },

    { name: 'T-Shirt', category: 'Merch', price: 500, qty: 1, image: 'https://cdn-icons-png.flaticon.com/512/892/892458.png' }
  ];

  getAll() {
    return this.items;
  }
}