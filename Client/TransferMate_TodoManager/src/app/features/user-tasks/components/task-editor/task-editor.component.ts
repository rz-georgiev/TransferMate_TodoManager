import { Component } from '@angular/core';
import { NgModule } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import e, { Router } from 'express';
import { ActivatedRoute } from '@angular/router';
import { ReadTaskDto } from '../../models/readTaskDto';
import { MatOption, MatSelect } from '@angular/material/select';
import { ReadStatusDto } from '../../models/readStatusDto';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { UserTaskService } from '../../services/user-tasks/user-task.service';
import { StatusesService } from '../../services/statuses/statuses.service';
import { BaseResponse } from '../../../../shared/models/baseResponse';

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
    ],
  templateUrl: './task-editor.component.html',
  styleUrl: './task-editor.component.css'
})
export class TaskEditorComponent {

  public editForm!: FormGroup;
  public data!: ReadTaskDto;
  public statuses!: ReadStatusDto[];

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private taskService: UserTaskService,
    private statusesService: StatusesService
  ) { }

  ngOnInit() {

    this.route.queryParams.subscribe(params => {
      if (params['data']) {
        this.data = JSON.parse(params['data']);
      }
    });
    
    this.statusesService.getAll().subscribe(x => {
      this.statuses = x.result;
    });

    this.editForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      dueDate: ['', []],
      statusId: ['', [Validators.required]],
    });

    this.editForm.patchValue({ 
      name: this.data.name,
      dueDate: this.data.dueDate,
    });
  }

  onSubmit(): void {
    if (this.editForm.valid) {
      console.log('Form submitted:', this.editForm.value);
    }
  }

}
