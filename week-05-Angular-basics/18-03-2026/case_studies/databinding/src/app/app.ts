import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {
  productName = 'Laptop';
  price = 1000;
  quantity = 1;
  isAvailable = true;
  image = 'https://picsum.photos/150';

  customerName = '';
  address = '';

  increaseQuantity() {
    this.quantity++;
  }

  decreaseQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  toggleAvailability() {
    this.isAvailable = !this.isAvailable;
  }

  get totalPrice() {
    return this.price * this.quantity;
  }
}