import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../../shared/shared.module'
import { HomePageComponent } from './home-page.component';
import { TrendingMoviesComponent } from './components/trending-movies/trending-movies.component';
import { AboutTitleComponent } from './components/about-title/about-title.component';
import { RouterModule } from '@angular/router';
import { WatchedTitlesComponent } from './components/watched-titles/watched-titles.component';

@NgModule({
  declarations: [
    HomePageComponent,
    TrendingMoviesComponent,
    AboutTitleComponent,
    WatchedTitlesComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule
  ]
})
export class HomePageModule { }
