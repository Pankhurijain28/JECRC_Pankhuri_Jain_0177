import { Directive, ElementRef, Input, OnChanges } from '@angular/core';

@Directive({
  selector: '[appPriceHighlight]',
  standalone: true
})
export class PriceHighlightDirective implements OnChanges {

  @Input() appPriceHighlight!: number;

  constructor(private el: ElementRef) {}

  ngOnChanges() {
    if (this.appPriceHighlight > 50000) {
      this.el.nativeElement.style.color = 'white';
      this.el.nativeElement.style.backgroundColor = 'red';
    } else {
      this.el.nativeElement.style.color = 'white';
      this.el.nativeElement.style.backgroundColor = 'green';
    }
  }
}