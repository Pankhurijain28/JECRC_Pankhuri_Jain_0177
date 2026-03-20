import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private items: any[] = [];
  private cartSubject = new BehaviorSubject<any[]>([]);

  cart$ = this.cartSubject.asObservable();

  addToCart(product: any) {
    const existing = this.items.find(p => p.id === product.id);

    if (existing) {
      existing.quantity++;
    } else {
      this.items.push({ ...product, quantity: 1 });
    }

    this.cartSubject.next(this.items);
  }
  clearCart() {
  this.items = [];
  this.cartSubject.next(this.items);
}

  removeItem(id: number) {
    this.items = this.items.filter(p => p.id !== id);
    this.cartSubject.next(this.items);
  }
}