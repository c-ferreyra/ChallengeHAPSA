import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';
import { Horse, HorseSearchFilters } from '../models/horse.model';

@Injectable({ providedIn: 'root' })
export class HorsesService {
  private readonly baseUrl = `${environment.apiUrl}/horses`;

  constructor(private readonly http: HttpClient) {}

  search(filters: HorseSearchFilters): Observable<Horse[]> {
    let params = new HttpParams();

    for (const [key, value] of Object.entries(filters)) {
      if (value !== null && value !== '') {
        params = params.set(key, value);
      }
    }

    return this.http.get<Horse[]>(this.baseUrl, { params });
  }
}
