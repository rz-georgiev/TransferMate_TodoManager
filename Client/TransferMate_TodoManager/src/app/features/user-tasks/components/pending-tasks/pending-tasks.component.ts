import { Component } from '@angular/core';
import { ReadTaskDto } from '../../models/readTaskDto';
import { UserTaskService } from '../../services/user-tasks/user-task.service';
import { ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { RouterLink, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { BaseTasksComponent } from "../base-tasks/base-tasks.component";

@Component({
  selector: 'app-pending-tasks',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatIconModule,
    RouterLink,
    MatButtonModule,
    RouterModule,
    BaseTasksComponent
],
  templateUrl: './pending-tasks.component.html',
  styleUrl: './pending-tasks.component.css'
})
export class PendingTasksComponent {

  displayedColumns: string[] = ['id', 'name', 'dueDate', 'statusName', 'edit'];
  dataSource = new MatTableDataSource<ReadTaskDto>();

  @ViewChild(MatPaginator, {static: true}) paginator!: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort!: MatSort;

  constructor(private service: UserTaskService) { }

  ngOnInit() {
    this.service.getPendingTasks().subscribe(x => {
      this.dataSource.data = x.result;
    });

    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}
