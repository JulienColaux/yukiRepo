import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserComponent } from './add-user.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddUserComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    AddUserComponent
  ]
})
export class AddUserModule { }
