import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Urls } from '../../../../shared/consts/urls';
import { BaseResponse } from '../../../../shared/models/baseResponse';
import { ReadStatusDto } from '../../models/readStatusDto';

@Injectable({
  providedIn: 'root'
})
export class StatusesService {

  private baseUrl = `${Urls.ApiUrl}`;

  constructor(private httpClient: HttpClient) { }

  // Extracting all status types from the api
  getAll(): Observable<BaseResponse<ReadStatusDto[]>> {
    return this.httpClient.get<BaseResponse<ReadStatusDto[]>>(`${this.baseUrl}/statuses`);
  }
}
