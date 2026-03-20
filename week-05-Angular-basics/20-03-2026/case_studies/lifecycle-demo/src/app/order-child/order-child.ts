import {
  Component,
  Input,
  OnChanges,
  OnInit,
  DoCheck,
  AfterContentInit,
  AfterContentChecked,
  AfterViewInit,
  AfterViewChecked,
  OnDestroy,
  SimpleChanges
} from '@angular/core';

import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-order-child',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './order-child.html',
  styleUrls: ['./order-child.css']
})
export class OrderChild implements
  OnChanges,
  OnInit,
  DoCheck,
  AfterContentInit,
  AfterContentChecked,
  AfterViewInit,
  AfterViewChecked,
  OnDestroy {

  @Input() orderData: any;

  logs: string[] = [];

  log(message: string) {
    this.logs.push(`${new Date().toLocaleTimeString()} - ${message}`);
  }

  ngOnChanges(changes: SimpleChanges) {
    this.log('ngOnChanges called');
  }

  ngOnInit() {
    this.log('ngOnInit called');
  }

  ngDoCheck() {
    this.log('ngDoCheck called');
  }

  ngAfterContentInit() {
    this.log('ngAfterContentInit called');
  }

  ngAfterContentChecked() {
    this.log('ngAfterContentChecked called');
  }

  ngAfterViewInit() {
    this.log('ngAfterViewInit called');
  }

  ngAfterViewChecked() {
    this.log('ngAfterViewChecked called');
  }

  ngOnDestroy() {
    this.log('ngOnDestroy called');
  }
}