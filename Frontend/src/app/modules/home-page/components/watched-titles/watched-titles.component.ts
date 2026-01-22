import { Component } from '@angular/core';
import { MovieService } from '../../../../shared/services/media/movie.service';
import { DBMovie } from '../../../../shared/models/DBMovie';

@Component({
  selector: 'app-watched-titles',
  templateUrl: './watched-titles.component.html',
  styleUrl: './watched-titles.component.css'
})
export class WatchedTitlesComponent {
  watchedTitles: DBMovie[] = [];

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.getWatchedTitles();
  }


  getWatchedTitles() {
    this.movieService.getWatchedTitles()
      .subscribe((watchedTitles: DBMovie[]) => this.watchedTitles = watchedTitles);
  }
}
