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
import { LoginModule } from './features/login/login.module';
import { HomeModule } from './features/home/home.module';
import { LoginService } from './core/services/login.service';
import { HttpClientModule } from '@angular/common/http';
import { AddReportModule } from './features/add-report/add-report.module';
import { CheckReportModule } from './features/check-report/check-report.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ButtonModule,
    InputTextModule,
    DropdownModule,
    FileUploadModule,
    TableModule,
    MessagesModule,
    LoginModule,
    HomeModule,
    HttpClientModule,
    AddReportModule,
    CheckReportModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
