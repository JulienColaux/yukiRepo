import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditProfilComponent } from './edit-profil.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {BrowserModule} from '@angular/platform-browser';
import {Button} from 'primeng/button';
import {DialogModule} from 'primeng/dialog';
import {DropdownModule} from 'primeng/dropdown';
import {TableModule} from 'primeng/table';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {CardModule} from 'primeng/card';
import {SharedModule} from 'primeng/api';



@NgModule({
  declarations: [EditProfilComponent],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    Button,
    DialogModule,
    DropdownModule,
    TableModule,
    BrowserAnimationsModule,
    CardModule,
    SharedModule
  ],
  exports: [
    EditProfilComponent
  ]
})
export class EditProfilModule { }
