import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { UsersComponent } from './users/users.component';
import { AddComponent } from './users/add/add.component';
import { EditComponent } from './users/edit/edit.component';
import { FormComponent } from './users/shared/form/form.component';
import { AppRoutingModule } from './app-routing.module'; 

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    AddComponent,
    EditComponent,
    FormComponent
  ],
  imports: [
    BrowserModule,
    StoreModule.forRoot({}, {}),
    EffectsModule.forRoot([]),
    StoreRouterConnectingModule.forRoot(),
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
