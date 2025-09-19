import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../../shared/shared.module'
import { HomePageComponent } from './home-page.component';
import { TrendingMoviesComponent } from './components/trending-movies/trending-movies.component';
import { AboutTitleComponent } from './components/about-title/about-title.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    HomePageComponent,
    TrendingMoviesComponent,
    AboutTitleComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule
  ]
})
export class HomePageModule { }
