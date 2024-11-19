import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckReportComponent } from './check-report/check-report.component';



@NgModule({
  declarations: [CheckReportComponent],
  imports: [
    CommonModule
  ],
  exports: [
    CheckReportComponent
  ]
})
export class CheckReportModule { }
