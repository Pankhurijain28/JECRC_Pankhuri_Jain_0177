import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MySelector } from './my-selector';

describe('MySelector', () => {
  let component: MySelector;
  let fixture: ComponentFixture<MySelector>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MySelector],
    }).compileComponents();

    fixture = TestBed.createComponent(MySelector);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
