import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs';

import { User } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  public users: User[] = [];
  private subscriptions: Subscription[] = [];

  constructor(
    private router: Router,
    private userService: UserService) { }

  public ngOnInit(): void {
    this.getUsers();
  }

  public addUser() {
    this.router.navigateByUrl('/user/add');
  }

  public editUser(user: User) {
    this.router.navigate(['/user', user.id, 'edit']);
  }

  private getUsers() {
    this.subscriptions.push(this.userService.getUsers().subscribe((users) => {
      this.users = users;
    }));
  }

  public ngOnDestroy() {
    if (this.subscriptions?.length > 0) {
      this.subscriptions.forEach(element => {
        element.unsubscribe();
      });
    }
  }
}
