import { Component } from '@angular/core';
import { BaseTasksComponent } from "../base-tasks/base-tasks.component";

@Component({
  selector: 'app-overdue-tasks',
  standalone: true,
  imports: [BaseTasksComponent],
  templateUrl: './overdue-tasks.component.html',
  styleUrl: './overdue-tasks.component.css'
})
export class OverdueTasksComponent {

}
