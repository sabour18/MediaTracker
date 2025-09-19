import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../../models/User';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  // TODO: hide api urls
  private apiUrl = 'https://localhost:44346/api/Users';
  constructor(private http: HttpClient){ }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl, { responseType: 'json'});
  }
}
