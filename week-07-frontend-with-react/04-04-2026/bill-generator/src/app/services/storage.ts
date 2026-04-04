import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  save(data: any) {
    localStorage.setItem('data', JSON.stringify(data));
  }

  get() {
    return JSON.parse(localStorage.getItem('data') || '[]');
  }
}