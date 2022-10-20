import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { FormlyFieldConfig } from '@ngx-formly/core';
import { Subscription } from 'rxjs';

import { User } from '../../models/user.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.css']
})
export class ManageComponent implements OnInit {
  public header: string = ''
  public model: User = new User();
  private subscriptions: Subscription[] = [];
  private emailRegex: RegExp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  public form = new FormGroup({});
  public fields: FormlyFieldConfig[] = [
    {
      key: 'firstName',
      type: 'input',
      props: {
        label: 'First Name:',
        required: true,
      },
      className: 'form-field'
    },
    {
      key: 'lastName',
      type: 'input',
      props: {
        label: 'Last Name:',
        required: true,
      },
      className: 'form-field'
    },
    {
      key: 'email',
      type: 'input',
      props: {
        label: 'Email address:',
        required: true,
      },
      validators: {
        email: {
          expression: (control: AbstractControl) => !control.value || this.emailRegex.test(control.value),
        }
      },
      className: 'form-field'
    }
  ];

  constructor(private router: Router,
    private route: ActivatedRoute,
    private userService: UserService) {
    this.route.params.subscribe(params => {
      this.model.id = params['id'];
    });
  }

  public ngOnInit() {
    if (this.model.id) {
      this.userService.getUsers().subscribe((users) => {
        this.model = users.find(x => x.id == this.model.id)!;
        if (!this.model) this.onBack(); // not a valid user id
      });

      this.header = "Edit User";
    }
    else {
      this.header = "Add User";
    }
  }

  public onSubmit() {
    if (!this.form.valid) {
      return;
    }

    this.subscriptions.push(this.userService.processUser(this.model).subscribe(() => {
      this.onBack();
    }));
  }

  public onDelete() {
    this.subscriptions.push(this.userService.deleteUser(this.model).subscribe(() => {
      this.onBack();
    }));
  }

  public onBack() {
    this.router.navigateByUrl('');
  }
}
