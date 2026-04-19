import {
  Component,
  Input,
  ChangeDetectionStrategy
} from '@angular/core';
import { StatsComponent } from '../stats/stats.component';
import { UserStats } from '../../models/user-stats.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, StatsComponent],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DashboardComponent {
  @Input() userStats!: UserStats;

  isExamMode = true; // toggle mode

  // Pure mutation (question requirement)
  updateLocally() {
    this.userStats.score = 100;
  }

  // Immutable fix
  updateImmutable() {
    this.userStats = {
      ...this.userStats,
      score: Math.floor(Math.random() * 100)
    };
  }

  // 🎮 Interactive mode only
  updateSlider(event: any) {
    if (!this.isExamMode) {
      this.userStats = {
        ...this.userStats,
        score: event.target.value
      };
    }
  }

  toggleMode() {
    this.isExamMode = !this.isExamMode;
  }
}