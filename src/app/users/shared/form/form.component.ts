import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormlyFieldConfig } from '@ngx-formly/core';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  form = new FormGroup({});
  model = { firstname: null, lastname: null, email: 'email@gmail.com' };
  fields: FormlyFieldConfig[] = [
    {
      key: 'firstname',
      type: 'input',
      props: {
        label: 'First Name',
        placeholder: 'Enter first name',
        required: true,
      }
    },
    {
      key: 'lasatname',
      type: 'input',
      props: {
        label: 'Laast Name',
        placeholder: 'Enter last name',
        required: true,
      }
    },
    {
      key: 'email',
      type: 'input',
      props: {
        label: 'Email address',
        placeholder: 'Enter email',
        required: true,
      }
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }



  onSubmit(model: any) {
    console.log(model);
  }
}
