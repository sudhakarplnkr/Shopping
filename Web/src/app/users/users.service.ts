import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigurationService } from '../core/configuration.service';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private httpClient: HttpClient, private config: ConfigurationService) {}
  loadUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(`${this.config.apiHost}/user`);
  }
}
