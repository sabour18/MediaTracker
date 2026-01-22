import { Component } from '@angular/core';
import { TMDbMovie } from '../../../../shared/models/TMDbMovie';
import { DBMovie } from '../../../../shared/models/DBMovie';
import { MovieService } from '../../../../shared/services/media/movie.service';
import { Router } from '@angular/router';
import { AuthService } from '../../../../shared/services/auth/auth.service';

@Component({
  selector: 'app-trending-movies',
  templateUrl: './trending-movies.component.html',
  styleUrl: './trending-movies.component.css'
})
export class TrendingMoviesComponent {
  isAuthenticated: boolean = false;
  trendingMovies: TMDbMovie[] = [];
  watchedTitles: DBMovie[] = [];

  constructor(private movieService: MovieService, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.getTrendingMovies();
    this.authService.isAuthenticated().subscribe(isAuthenticated => {
      this.isAuthenticated = isAuthenticated;
    });

    this.getWatchedTitles();

    console.log(this.watchedTitles);
  }

  getTrendingMovies() {
    this.movieService.getTrendingMovies()
      .subscribe((trendingMovies: TMDbMovie[]) => this.trendingMovies = trendingMovies);
  }

  saveFavouriteTitle(title: any) {
    this.movieService.saveFavouriteTitle(title);
  }

  // currently loaded on home and watched list
  // can maybe store into a store? (havent done in angular)
  getWatchedTitles() {
    this.movieService.getWatchedTitles()
      .subscribe((watchedTitles: DBMovie[]) => this.watchedTitles = watchedTitles);
  }

  selectMovie(movie: TMDbMovie) {
    this.movieService.setAboutTitle(movie);
    this.router.navigate(['/about']);
  }

  isInWatched(movie: TMDbMovie) {
    return this.watchedTitles.some(watched => watched.mediaId === movie.id);
  }
}
