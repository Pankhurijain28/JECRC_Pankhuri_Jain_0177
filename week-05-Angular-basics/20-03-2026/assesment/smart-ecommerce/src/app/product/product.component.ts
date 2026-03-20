import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {

  searchText = '';
  selectedCategory = '';

  products = [
    { id: 1, name: 'iPhone', price: 70000, category: 'Electronics', rating: 5, image: 'https://via.placeholder.com/200', quantity: 1 },
    { id: 2, name: 'Shoes', price: 3000, category: 'Fashion', rating: 4, image: 'https://via.placeholder.com/200', quantity: 1 },
    { id: 3, name: 'Laptop', price: 80000, category: 'Electronics', rating: 5, image: 'https://via.placeholder.com/200', quantity: 1 }
  ];

  constructor(private cartService: CartService) {}

  get filteredProducts() {
    return this.products.filter(p =>
      p.name.toLowerCase().includes(this.searchText.toLowerCase()) &&
      (this.selectedCategory === '' || p.category === this.selectedCategory)
    );
  }

  addToCart(product: any) {
    this.cartService.addToCart(product);
  }
}