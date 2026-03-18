import { Directive, ElementRef, Input, OnChanges } from '@angular/core';

@Directive({
  selector: '[appStatusColor]',
  standalone: true
})
export class StatusColorDirective implements OnChanges {

  @Input() appStatusColor!: number; // marks
  @Input() passingMarks: number = 50;

  constructor(private el: ElementRef) {}

  ngOnChanges() {
    if (this.appStatusColor >= this.passingMarks) {
      this.el.nativeElement.style.color = 'white';
      this.el.nativeElement.style.backgroundColor = 'green';
    } else {
      this.el.nativeElement.style.color = 'white';
      this.el.nativeElement.style.backgroundColor = 'red';
    }
  }
}