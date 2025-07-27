import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfig } from '../configurations/api-config';
import { catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AesService {
  http = inject(HttpClient)

  encrypt(body: any) {
    return this.http.post<any>(`${ApiConfig.ApiUrl}Aes/encrypt/`, body).pipe(
      map(response => {
        return response
      }),
      catchError(error => { throw error.error }))
  }

  decrypt(body: any) {
    return this.http.post<any>(`${ApiConfig.ApiUrl}Aes/decrypt/`, body).pipe(
      map(response => {
        return response
      }),
      catchError(error => { throw error.error }))
  }
}
