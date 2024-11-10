import { CommonModule } from '@angular/common';
import { Component, Input, ViewChild } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { RouterLink, RouterModule } from '@angular/router';
import { ReadTaskDto } from '../../models/readTaskDto';
import { UserTaskService } from '../../services/user-tasks/user-task.service';
import { UtcToLocalPipe } from "../../../../core/pipes/utc-to-local.pipe";

@Component({
  selector: 'app-base-tasks',
  standalone: true,
  imports: [CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    RouterLink,
    MatButtonModule,
    RouterModule, UtcToLocalPipe],
  templateUrl: './base-tasks.component.html',
  styleUrl: './base-tasks.component.css'
})
export class BaseTasksComponent {

  @Input() isPendingTasks!: boolean;
  
  displayedColumns: string[] = ['id', 'name', 'dueDate', 'statusName', 'edit'];
  dataSource = new MatTableDataSource<ReadTaskDto>();

  @ViewChild(MatPaginator, {static: true}) paginator!: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort!: MatSort;

  constructor(private service: UserTaskService) { }

  ngOnInit() {
    if (this.isPendingTasks) {
      this.service.getPendingTasks().subscribe(x => {
        this.dataSource.data = x.result;
      });
    }
    else {
      this.service.getOverdueTasks().subscribe(x => {
        this.dataSource.data = x.result;
      });
    }

    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}
