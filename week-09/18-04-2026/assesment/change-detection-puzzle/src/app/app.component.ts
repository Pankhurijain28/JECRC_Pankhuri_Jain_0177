import { Component } from '@angular/core';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserStats } from './models/user-stats.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [DashboardComponent],
  templateUrl: './app.component.html'
})
export class AppComponent {
  userStats: UserStats = {
    name: 'Pankhuri',
    score: 50
  };
}