import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-invoice-preview',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './invoice-preview.component.html',
  styleUrls: ['./invoice-preview.component.css']
})
export class InvoicePreviewComponent {

  @Input() items: any[] = [];
  @Input() total = 0;
  @Input() tax = 0;
  @Input() discount = 0;

  invoiceNumber: number = Math.floor(Math.random() * 100000);
  today: Date = new Date();

  print() {
    window.print();
  }

  generatePDF() {
    const data = document.querySelector('.invoice') as HTMLElement;

    html2canvas(data).then(canvas => {
      const img = canvas.toDataURL('image/png');
      const pdf = new jsPDF();

      pdf.addImage(img, 'PNG', 10, 10, 180, 0);
      pdf.save('invoice.pdf');
    });
  }
}