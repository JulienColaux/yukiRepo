import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddReportComponent } from './add-report/add-report.component';



@NgModule({
  declarations: [AddReportComponent],
  imports: [
    CommonModule
  ],
  exports: [
    AddReportComponent
  ]
})
export class AddReportModule { }
