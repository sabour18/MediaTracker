import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TMDbMovie } from '../../models/TMDbMovie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  private baseUrl = 'https://localhost:44346/TMDb/';
  private selectedTitle: any = null;

  constructor(private http: HttpClient) { }

  getTrendingMovies(): Observable<TMDbMovie[]> {
    return this.http.get<TMDbMovie[]>(`${this.baseUrl}movie/trending`);
  }

  setAboutTitle(title: any) {
    this.selectedTitle = title;
  }
  getAboutTitle() {
    return this.selectedTitle;
  }
  /*searchMovies(query: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/search?query=${query}`);
  }*/
}
