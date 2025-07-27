import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfig } from '../configurations/api-config';
import { catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Base64Service {
  http = inject(HttpClient)

  encodeToBase64(body: any) {
    return this.http.post<any>(`${ApiConfig.ApiUrl}Base64/encode/`, body).pipe(
      map(response => {
        return response
      }),
      catchError(error => { throw error.error }))
  }

  decodeBase64Text(body: any) {
    return this.http.post<any>(`${ApiConfig.ApiUrl}Base64/decode/`, body).pipe(
      map(response => {
        return response
      }),
      catchError(error => { throw error.error }))
  }
}
