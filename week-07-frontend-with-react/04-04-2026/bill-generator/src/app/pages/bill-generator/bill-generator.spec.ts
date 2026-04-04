export class BillGeneratorComponent {

  items: any[] = [];
  discount = 0;

  addItem(item: any) {
    this.items.push(item);
  }

  get subtotal() {
    return this.items.reduce((s, i) => s + i.price * i.qty, 0);
  }

  get tax() {
    return this.subtotal * 0.18;
  }

  get total() {
    return this.subtotal + this.tax - this.discount;
  }
}