import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { User } from '../models/user.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  public getUsers(): Observable<User[]> {
    return this.http.get(`${environment.baseUrl}/api/user/get`).pipe(map(response => {
      return response as User[];
    }));
  }

  public processUser(user: User) {
    return this.http.post(`${environment.baseUrl}/api/user/${user.id ? 'edit' : 'add'}`, JSON.stringify(user), { headers: { 'content-type': 'application/json' } });
  }

  public deleteUser(user: User) {
    return this.http.delete(`${environment.baseUrl}/api/user/${user.id}`);
  }
}
