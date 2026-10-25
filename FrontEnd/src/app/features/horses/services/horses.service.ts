import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../../environments/environment';
import {
  ApiResult,
  CreateHorseRequest,
  HorseDto,
  HorseStatus,
  HorseType,
  UpdateHorseRequest
} from '../models/horse.model';

@Injectable({ providedIn: 'root' })
export class HorsesService {
  private readonly baseUrl = `${environment.apiUrl}/horses`;

  constructor(private readonly http: HttpClient) {}

  // Sin status el backend devuelve solo los habilitados.
  getAll(name: string, status: HorseStatus, type?: HorseType): Observable<HorseDto[]> {
    let params = new HttpParams();

    if (name != undefined)
      params = params.set('name', name);

    params = params.set('status', status);

    // sin type el backend no filtra por tipo
    if (type)
      params = params.set('type', type);

    return this.http
      .get<ApiResult<HorseDto[]>>(this.baseUrl, { params })
      .pipe(map((result) => result.value ?? []));
  }

  getById(id: string): Observable<HorseDto> {
    return this.http
      .get<ApiResult<HorseDto>>(`${this.baseUrl}/${id}`)
      .pipe(map((result) => result.value as HorseDto));
  }

  // Devuelve el id del caballo creado.
  create(request: CreateHorseRequest): Observable<string> {
    return this.http
      .post<ApiResult<string>>(`${this.baseUrl}/create`, request)
      .pipe(map((result) => result.value as string));
  }

  update(id: string, request: UpdateHorseRequest): Observable<void> {
    return this.http.put<ApiResult>(`${this.baseUrl}/${id}`, request).pipe(map(() => undefined));
  }

  // Baja logica.
  disable(id: string): Observable<void> {
    return this.http.patch<ApiResult>(`${this.baseUrl}/${id}`, null).pipe(map(() => undefined));
  }

  enable(id: string): Observable<void> {
    return this.http.patch<ApiResult>(`${this.baseUrl}/${id}/enable`, null).pipe(map(() => undefined));
  }
}
