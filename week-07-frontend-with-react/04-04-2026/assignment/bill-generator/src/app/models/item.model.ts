export interface Item {
  name: string;
  category: 'Entrance' | 'Donation' | 'Food' | 'Service' | 'Merch' | 'Custom';
  price: number;
  qty: number;
  image?: string;
}