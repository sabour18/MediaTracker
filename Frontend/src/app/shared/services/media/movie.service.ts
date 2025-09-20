import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TMDbMovie } from '../../models/TMDbMovie';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  private baseUrl = 'https://localhost:44346/api/';
  private selectedTitle: any = null;

  constructor(private http: HttpClient, private authService: AuthService) { }

  getTrendingMovies(): Observable<TMDbMovie[]> {
    return this.http.get<TMDbMovie[]>(`${this.baseUrl}TMDb/movie/trending`);
  }

  setAboutTitle(title: any) {
    this.selectedTitle = title;
  }
  getAboutTitle() {
    return this.selectedTitle;
  }

  saveFavouriteTitle(title: any) {
    const userId = localStorage.getItem('user_id')

    const body = {
      title: title,
      userId: userId
    };
    this.http.post(`${this.baseUrl}media/saveFavourite`, body)
      .subscribe({
        next: (res) => console.log('Saved successfully', res),
        error: (err) => console.error('Error saving favourite', err)
      });
  }

  getFavouriteTitles(): Observable<TMDbMovie[]> {
    const userId = localStorage.getItem('user_id')
    return this.http.get<TMDbMovie[]>(`${this.baseUrl}Users/favourites`, {
      params: { userId: userId || '' }
    });
  }
  /*searchMovies(query: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/search?query=${query}`);
  }*/
}
