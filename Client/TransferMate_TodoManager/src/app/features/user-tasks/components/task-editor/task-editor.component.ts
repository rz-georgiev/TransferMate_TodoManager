import { Component } from '@angular/core';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-task-editor',
  standalone: true,
  imports: [ BrowserModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule],
  templateUrl: './task-editor.component.html',
  styleUrl: './task-editor.component.css'
})
export class TaskEditorComponent {
 
  public editForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.editForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      dueDate: ['', []],
      statusId: ['', [Validators.required]],
    });
  }

  onSubmit(): void {
    if (this.editForm.valid) {
      console.log('Form submitted:', this.editForm.value);
    }
  }

  onReikset(): void {
    this.editForm.reset();
  }
}
