import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { stat } from 'fs';

@Component({
  selector: 'app-root',
  imports: [CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  showProducts = true;

  products = [
    {name: 'Phone', price: 699, status: 'Available'},
    {name: 'Laptop', price: 999, status: 'Out of Stock'},
    {name: 'Headphones', price: 199, status: 'Available'},
  ];
}
