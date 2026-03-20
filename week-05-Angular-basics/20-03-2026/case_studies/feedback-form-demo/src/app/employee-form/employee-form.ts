import { Component } from '@angular/core';
import {
  ReactiveFormsModule,
  FormControl,
  FormGroup,
  FormArray,
  FormRecord,
  Validators
} from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './employee-form.html',
  styleUrls: ['./employee-form.css']
})
export class EmployeeFormComponent {

  name = new FormControl('', Validators.required);

  account = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required)
  });

  skills = new FormArray([
    new FormControl('Angular'),
  ]);
  preferences = new FormRecord({
    darkmode: new FormControl(false),
    notifications: new FormControl(true)
  });

  addSkill(){
    this.skills.push(new FormControl(''));
  }

  removeSkill(index: number){
    this.skills.removeAt(index);
  }

  addPreference(){
    const key = 'pref_' + Object.keys(this.preferences.controls).length;
    this.preferences.addControl(key, new FormControl(false));
  }

  submit(){
    const data = {
      name: this.name.value,
      account: this.account.value,
      skills: this.skills.value,
      preferences: this.preferences.value
    };
    console.log('Employee Data ', data);
    alert(JSON.stringify(data, null, 2));
  }
}