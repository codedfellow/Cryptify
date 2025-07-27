import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfig } from '../configurations/api-config';
import { catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class XorCipherService {
  http = inject(HttpClient)

  encrypt(body: any) {
    return this.http.post<any>(`${ApiConfig.ApiUrl}XorCipher/encrypt/`, body).pipe(
      map(response => {
        return response
      }),
      catchError(error => { throw error.error }))
  }

  decrypt(body: any) {
    return this.http.post<any>(`${ApiConfig.ApiUrl}XorCipher/decrypt/`, body).pipe(
      map(response => {
        return response
      }),
      catchError(error => { throw error.error }))
  }
}
