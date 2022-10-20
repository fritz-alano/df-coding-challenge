import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ManageComponent } from './users/manage/manage.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  { path: 'user/add', component: ManageComponent },
  { path: 'user/:id/edit', component: ManageComponent },
  { path: '**', component: UsersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }