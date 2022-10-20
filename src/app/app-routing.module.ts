import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AddComponent } from './users/add/add.component';
import { EditComponent } from './users/edit/edit.component';

const routes: Routes = [
  { path: 'user/add', component: AddComponent },
  { path: 'user/edit', component: EditComponent },
  { path: '**', component: AppComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }