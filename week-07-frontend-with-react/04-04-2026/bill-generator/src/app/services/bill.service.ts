import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BillService {

  saveBill(data: any) {
    console.log("Saved:", data);

    // ✅ return observable
    return of(true);
  }
}