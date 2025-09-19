import { Component } from '@angular/core';
import { TMDbMovie } from '../../../../shared/models/TMDbMovie';
import { MovieService } from '../../../../shared/services/media/movie.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-trending-movies',
  templateUrl: './trending-movies.component.html',
  styleUrl: './trending-movies.component.css'
})
export class TrendingMoviesComponent {

  trendingMovies: TMDbMovie[] = [];

  constructor(private movieService: MovieService, private router: Router) { }

  ngOnInit(): void {
    this.getTrendingMovies();
  }

  getTrendingMovies() {
    this.movieService.getTrendingMovies()
      .subscribe((trendingMovies: TMDbMovie[]) => this.trendingMovies = trendingMovies);
  }

  selectMovie(movie: any) {
    this.movieService.setAboutTitle(movie);
    this.router.navigate(['/about']);
  }
}
