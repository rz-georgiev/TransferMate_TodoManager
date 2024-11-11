import { Component } from '@angular/core';
import { NgModule } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule, formatDate } from '@angular/common';
import { ActivatedRoute, Route } from '@angular/router';
import { ReadTaskDto } from '../../models/readTaskDto';
import { MatOption, MatSelect } from '@angular/material/select';
import { ReadStatusDto } from '../../models/readStatusDto';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { UserTaskService } from '../../services/user-tasks/user-task.service';
import { StatusesService } from '../../services/statuses/statuses.service';
import { BaseResponse } from '../../../../shared/models/baseResponse';
import { MatNativeDateModule } from '@angular/material/core';
import { NewTaskDto } from '../../models/newTaskDto';
import { Router } from '@angular/router';
import { BaseTasksComponent } from "../base-tasks/base-tasks.component";

@Component({
  selector: 'app-task-editor',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatSelect,
    MatOption,
    MatDatepickerModule,
    MatNativeDateModule,
    BaseTasksComponent
  ],
  templateUrl: './task-editor.component.html',
  styleUrl: './task-editor.component.css'
})
export class TaskEditorComponent {


  public editForm!: FormGroup;
  public data!: any;
  public statuses!: ReadStatusDto[];
  public isInEditMode!: boolean;
  private isPendingTasks!: boolean;

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private taskService: UserTaskService,
    private statusesService: StatusesService
  ) {
    this.editForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      dueDate: ['', []],
      statusId: ['', []],
    });
  }

  ngOnInit() {

    this.route.queryParams.subscribe(params => {
      if (params['data']) {
        this.data = JSON.parse(params['data']);
      }
      if (params['isPendingTasks']) {
        this.isPendingTasks = JSON.parse(params['isPendingTasks']);
      }
    });

    this.statusesService.getAll().subscribe(x => {
      this.statuses = x.result;
    });

    if (this.data?.id > 0) {
      this.editForm.patchValue({
        name: this.data.name,
        dueDate: this.data.dueDate,
        statusId: this.data.statusId,
      });
    }
  }

  onSubmit() {

    let selectedDate = this.editForm.value.dueDate // Assume this gets the selected date from the form
    selectedDate = new Date(selectedDate);
    const utcDate = new Date(Date.UTC(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate()));

    if (this.data?.id > 0) {
      this.taskService.updateTask({
        id: this.data.id,
        name: this.editForm.value.name,
        dueDate: this.editForm.value.dueDate === ''
         || this.editForm.value.dueDate === null
          ? null
          : utcDate,
        statusId: this.editForm.value.statusId,
      }).subscribe(x => {
        if (x.isOk) {
          if (this.isPendingTasks) {
            this.router.navigate(['/pending-tasks']);
          } else {
            this.router.navigate(['/overdue-tasks']);
          }
        }
      });
    }
    else {
      
      this.taskService.createTask({
        name: this.editForm.value.name,
        dueDate: this.editForm.value.dueDate === ''
        || this.editForm.value.dueDate === null
          ? null
          : utcDate
      }).subscribe(x => {
        if (x.isOk) {
          if (this.isPendingTasks) {
            this.router.navigate(['/pending-tasks']);
          } else {
            this.router.navigate(['/overdue-tasks']);
          }
        }
      });
    }
  }
}
