import { Routes } from '@angular/router';

import { Home } from './home/home';
import { User } from './user/user';
import { Product } from './product/product';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'user', component: User },
  { path: 'product', component: Product }
];