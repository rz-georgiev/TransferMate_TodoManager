import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Urls } from '../../../../shared/consts/urls';
import { Observable } from 'rxjs';
import { BaseResponse } from '../../../../shared/models/baseResponse';
import { ReadTaskDto } from '../../models/readTaskDto';
import { NewTaskDto } from '../../models/newTaskDto';
import { UpdateTaskDto } from '../../models/updateTaskDto';

@Injectable({
  providedIn: 'root'
})
export class UserTaskService {

  private baseUrl = `${Urls.ApiUrl}`;

  constructor(private httpClient: HttpClient) { }

  // Used to create a new user task
  createTask(data: NewTaskDto): Observable<BaseResponse<ReadTaskDto>> {
    return this.httpClient.post<BaseResponse<ReadTaskDto>>(`${this.baseUrl}/createTask`, data);
  }

  // Used to modify old user task
  updateTask(data: UpdateTaskDto): Observable<BaseResponse<ReadTaskDto>> {
    return this.httpClient.post<BaseResponse<ReadTaskDto>>(`${this.baseUrl}/updateTask`, data);
  }

   // Returns all pendings tasks which due date is before the creation date of the task
  getPendingTasks(): Observable<BaseResponse<ReadTaskDto[]>> {
    return this.httpClient.get<BaseResponse<ReadTaskDto[]>>(`${this.baseUrl}/getPendingTasks`,);
  }

  // Returns all pendings tasks which due date is after the creation date of the task
  getOverdueTasks(): Observable<BaseResponse<ReadTaskDto[]>> {
    return this.httpClient.get<BaseResponse<ReadTaskDto[]>>(`${this.baseUrl}/getOverdueTasks`);
  }

}
