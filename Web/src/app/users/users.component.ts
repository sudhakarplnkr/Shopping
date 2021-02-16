import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user.model';
import { UsersService } from './users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  users: Observable<User[]>;
  constructor(private roleService: UsersService) { }
  ngOnInit(): void {
    this.users = this.roleService.loadUsers();
  }
}
