import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './shared/services/auth/auth.guard';

import { LoginPageComponent } from './modules/login-page/login-page.component';
import { HomePageComponent } from './modules/home-page/home-page.component';
import { AboutTitleComponent } from './modules/home-page/components/about-title/about-title.component';

// Add canActivate: [AuthGuard] to a route path to restrict non logged in users
const routes: Routes = [
  { path: '', component: HomePageComponent},
  { path: 'login', component: LoginPageComponent },
  { path: 'about', component: AboutTitleComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
