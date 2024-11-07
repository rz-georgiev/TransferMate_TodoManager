import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserTasksComponent } from "../../../features/user-tasks/components/user-tasks/user-tasks.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, UserTasksComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TransferMate_TodoManager';
}
