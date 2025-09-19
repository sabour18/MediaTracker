import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MovieService } from '../../../../shared/services/media/movie.service';

@Component({
  selector: 'app-about-title',
  templateUrl: './about-title.component.html',
  styleUrl: './about-title.component.css'
})
export class AboutTitleComponent {
  title: any;

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.title = this.movieService.getAboutTitle();
  }
}
