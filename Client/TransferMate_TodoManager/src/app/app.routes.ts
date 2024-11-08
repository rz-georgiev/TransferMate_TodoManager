import { Routes } from '@angular/router';
import { PendingTasksComponent } from './features/user-tasks/components/pending-tasks/pending-tasks.component';
import { OverdueTasksComponent } from './features/user-tasks/components/overdue-tasks/overdue-tasks.component';
import { TaskEditorComponent } from './features/user-tasks/components/task-editor/task-editor.component';

export const routes: Routes = [
    { path: 'task-editor', component: TaskEditorComponent },
    { path: 'pending-tasks', component: PendingTasksComponent },
    { path: 'overdue-tasks', component: OverdueTasksComponent },
    {
        path: '',
        component: PendingTasksComponent,
        pathMatch: 'full'
    },
    { path: '**', component: PendingTasksComponent }
];
