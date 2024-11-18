import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { FileUploadModule } from 'primeng/fileupload';
import { TableModule } from 'primeng/table';
import { MessagesModule } from 'primeng/messages';



@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ButtonModule,
    InputTextModule,
    DropdownModule,
    FileUploadModule,
    TableModule,
    MessagesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
