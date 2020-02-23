import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginPageComponent } from '../app/login-page/login-page.component';
import { UserDashboardComponent } from '../app/user-dashboard/user-dashboard.component';

const routes: Routes = [
  { path: 'home', component: LoginPageComponent },
  { path: 'dashboard', component: UserDashboardComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
