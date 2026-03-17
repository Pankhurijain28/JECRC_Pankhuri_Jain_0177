import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, CommonModule],

  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {
  patientName: string = '';
  doctor: string = '';
  date: string = '';
  consultationType: string = '';
  symptoms: string = '';

  fee: number = 0;
  message: string = '';

  today: string = new Date().toISOString().split('T')[0];

  updateFee() {
    if (this.consultationType === 'Online') this.fee = 300;
    else if (this.consultationType === 'Offline') this.fee = 500;
    else this.fee = 0;
  }

  bookAppointment() {
    if (!this.patientName || !this.doctor || !this.date || !this.consultationType) {
      this.message = "Please fill all required fields!";
      return;
    }
    this.message = "Appointment Booked Successfully!";
  }
}