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

  createTask(data: NewTaskDto): Observable<BaseResponse<ReadTaskDto>> {
    return this.httpClient.post<BaseResponse<ReadTaskDto>>(`${this.baseUrl}/createTask`, data);
  }

  updateTask(data: UpdateTaskDto): Observable<BaseResponse<ReadTaskDto>> {
    return this.httpClient.post<BaseResponse<ReadTaskDto>>(`${this.baseUrl}/updateTask`, data);
  }

  getPendingTasks(): Observable<BaseResponse<ReadTaskDto[]>> {
    return this.httpClient.get<BaseResponse<ReadTaskDto[]>>(`${this.baseUrl}/getPendingTasks`,);
  }

  getOverdueTasks(): Observable<BaseResponse<ReadTaskDto[]>> {
    return this.httpClient.get<BaseResponse<ReadTaskDto[]>>(`${this.baseUrl}/getOverdueTasks`);
  }

}
