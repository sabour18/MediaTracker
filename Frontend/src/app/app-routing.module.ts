import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './shared/services/auth/auth.guard';
import { GuestGuard } from './shared/services/guest-guard/guest.guard';

import { LoginPageComponent } from './modules/login-page/login-page.component';
import { HomePageComponent } from './modules/home-page/home-page.component';
import { AboutTitleComponent } from './modules/home-page/components/about-title/about-title.component';
import { WatchedTitlesComponent } from './modules/home-page/components/watched-titles/watched-titles.component';
import { RegisterComponent } from './modules/login-page/components/register/register.component';

// Add canActivate: [AuthGuard] to a route path to restrict non logged in users
const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'about', component: AboutTitleComponent },
  { path: 'login', component: LoginPageComponent, canActivate: [GuestGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [GuestGuard] },
  { path: 'watched', component: WatchedTitlesComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
