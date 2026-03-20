import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-feedback-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './feedback-form.html',
  styleUrls: ['./feedback-form.css']
})
export class FeedbackFormComponent {

  departments = ['HR', 'Development', 'Design', 'QA'];
  
  allSkills = ['Angular', 'React', 'Node', 'Python'];

 
  feedback = {
    name: '',
    email: '',
    department: '',
    rating:'',
    comments: '',
    skills: [] as string[],
  };

  
  submitForm(form: NgForm) {
    if (form.valid) {
      console.log('Feedback Submitted ', this.feedback);

      alert(JSON.stringify(this.feedback, null, 2));

      form.resetForm();

      this.feedback.skills = [];
    } else {
      alert('Please fill all required fields');
    }
  }
  updateSkills(skill: string, isChecked: boolean) {
    if (isChecked) {
      this.feedback.skills.push(skill);
    } else {
      this.feedback.skills = this.feedback.skills.filter(s => s !== skill);
    }
  }
}