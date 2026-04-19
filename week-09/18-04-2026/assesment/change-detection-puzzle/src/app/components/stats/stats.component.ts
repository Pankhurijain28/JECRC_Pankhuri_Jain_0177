import { Component, Input } from '@angular/core';
import { UserStats } from '../../models/user-stats.model';

@Component({
  selector: 'app-stats',
  standalone: true,
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent {
  @Input() userStats!: UserStats;
}