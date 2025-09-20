import { Component } from '@angular/core';
import { TMDbMovie } from '../../../../shared/models/TMDbMovie';
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
  favouritedTitles: any[] = [];

  constructor(private movieService: MovieService, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.getTrendingMovies();
    this.authService.isAuthenticated().subscribe(isAuthenticated => {
      this.isAuthenticated = isAuthenticated;
    });
  }

  getTrendingMovies() {
    this.movieService.getTrendingMovies()
      .subscribe((trendingMovies: TMDbMovie[]) => this.trendingMovies = trendingMovies);
  }

  saveFavouriteTitle(title: any) {
    this.movieService.saveFavouriteTitle(title);
  }

  getFavouritedTitles() {
  }

  selectMovie(movie: any) {
    this.movieService.setAboutTitle(movie);
    this.router.navigate(['/about']);
  }
}
