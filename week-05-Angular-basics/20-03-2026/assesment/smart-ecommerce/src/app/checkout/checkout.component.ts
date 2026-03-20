import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormArray } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {

  form!: FormGroup;  // 🔥 declare only

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      name: [''],
      address: [''],
      email: [''],
      phone: [''],
      zip: [''],
      gender: [''],
      delivery: ['Standard'],
      terms: [false],
      subscribe: [false],
      city: [''],
      state: [''],
      country: [''],
      date: [''],
      instructions: [''],
      payment: [''],
      addresses: this.fb.array([])
    });
  }

  get addresses() {
    return this.form.get('addresses') as FormArray;
  }

  addAddress() {
    this.addresses.push(this.fb.control(''));
  }
}