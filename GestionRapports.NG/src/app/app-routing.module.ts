import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/login/login/login.component';
import { HomeComponent } from './features/home/home/home.component';
import { AddReportComponent } from './features/add-report/add-report/add-report.component';
import { CheckReportComponent } from './features/check-report/check-report/check-report.component';
import { AddUserComponent } from './features/add-user/add-user.component';
import {EditProfilComponent} from './features/edit-profil/edit-profil.component';

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
  },
  {
    path: 'addUser', component: AddUserComponent
  },
  {
    path: 'editProfil', component: EditProfilComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
