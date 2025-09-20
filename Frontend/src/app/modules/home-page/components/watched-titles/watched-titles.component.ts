import { Component } from '@angular/core';
import { MovieService } from '../../../../shared/services/media/movie.service';
import { TMDbMovie } from '../../../../shared/models/TMDbMovie';

@Component({
  selector: 'app-watched-titles',
  templateUrl: './watched-titles.component.html',
  styleUrl: './watched-titles.component.css'
})
export class WatchedTitlesComponent {
  favouriteTitles: TMDbMovie[] = [];

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.getFavouriteTitles();
  }

  getFavouriteTitles() {
    this.movieService.getFavouriteTitles()
    .subscribe((favouriteTitles: TMDbMovie[]) => this.favouriteTitles = favouriteTitles);
  }
}
