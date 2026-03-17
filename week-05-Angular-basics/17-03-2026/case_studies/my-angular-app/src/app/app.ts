import { Component } from '@angular/core';
import { Product } from './product/product';
import { User } from './user/user';
import { Home } from './home/home';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Home,User,Product],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class AppComponent {
}