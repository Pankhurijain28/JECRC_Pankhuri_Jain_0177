import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from '../services/cart.service';

@Component({
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {

  cartItems: any[] = [];

  constructor(private cartService: CartService) {
    this.cartService.cart$.subscribe(data => this.cartItems = data);
  }

  increase(item: any) {
    item.quantity++;
  }

  decrease(item: any) {
    if (item.quantity > 1) item.quantity--;
  }

  remove(id: number) {
    this.cartService.removeItem(id);
  }

  clear() {
    this.cartService.clearCart();
  }

  get total() {
    return this.cartItems.reduce((sum, i) => sum + i.price * i.quantity, 0);
  }
}