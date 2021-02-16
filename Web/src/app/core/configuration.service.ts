import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  constructor() { }

  get apiHost(): string{
    return 'http://localhost:8080';
  }
}
