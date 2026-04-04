export interface Item {
  id?: number;
  name: string;
  category: 'Entrance' | 'Donation' | 'Product' | 'Custom';
  price: number;
  qty: number;
  isVariablePrice?: boolean;
}