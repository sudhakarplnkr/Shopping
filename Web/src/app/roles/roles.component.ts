import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Role } from './role.model';
import { RolesService } from './roles.service';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent implements OnInit {
  roles: Observable<Role[]>;
  constructor(private roleService: RolesService) { }
  ngOnInit(): void {
    this.roles = this.roleService.loadRoles();
  }
}
