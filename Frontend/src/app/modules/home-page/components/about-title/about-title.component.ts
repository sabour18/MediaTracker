import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MovieService } from '../../../../shared/services/media/movie.service';
import { AuthService } from '../../../../shared/services/auth/auth.service';

@Component({
  selector: 'app-about-title',
  templateUrl: './about-title.component.html',
  styleUrl: './about-title.component.css'
})
export class AboutTitleComponent {
  isAuthenticated: boolean = false;
  title: any;

  constructor(private movieService: MovieService, private authService: AuthService) { }

  ngOnInit() {
    this.title = this.movieService.getAboutTitle();
    this.authService.isAuthenticated().subscribe(isAuthenticated => {
      this.isAuthenticated = isAuthenticated;
    });
  }
}
