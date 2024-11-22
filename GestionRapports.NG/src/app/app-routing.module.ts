import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/login/login/login.component';
import { HomeComponent } from './features/home/home/home.component';
import { AddReportComponent } from './features/add-report/add-report/add-report.component';
import { CheckReportComponent } from './features/check-report/check-report/check-report.component';

const routes: Routes = [
  {
    path: '', component: LoginComponent
  },
  {
    path: 'home', component: HomeComponent
  },
  {
    path: 'addReport', component: AddReportComponent
  },
  {
    path: 'checkReport', component: CheckReportComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
