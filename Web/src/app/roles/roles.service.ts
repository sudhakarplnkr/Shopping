import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from '../core/configuration.service';
import { Role } from './role.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RolesService {
  constructor(private httpClient: HttpClient, private config: ConfigurationService) {
  }

  loadRoles(): Observable<Role[]> {
    return this.httpClient.get<Role[]>(`${this.config.apiHost}/role`);
  }
}
