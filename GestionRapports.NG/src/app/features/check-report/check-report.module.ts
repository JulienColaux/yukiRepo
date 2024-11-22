import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckReportComponent } from './check-report/check-report.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [CheckReportComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    CheckReportComponent
  ]
})
export class CheckReportModule { }
