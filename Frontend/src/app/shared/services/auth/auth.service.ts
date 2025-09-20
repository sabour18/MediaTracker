import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { User } from '../../models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:44346/api/auth';
  private tokenKey = 'auth_token';
  private userIdKey = 'user_id';
  private usernameKey = 'username';
  private authStatus = new BehaviorSubject<boolean>(this.hasToken());
  private currentUserSubject = new BehaviorSubject<{ userId: string; username: string } | null>(null);

  constructor(private http: HttpClient, private router: Router) { }

  login(credentials: { username: string; password: string }): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, credentials).pipe(
      tap(response => {
        // Store the token, userId, and username in local storage
        localStorage.setItem(this.tokenKey, response.token);
        localStorage.setItem(this.userIdKey, response.userId);
        localStorage.setItem(this.usernameKey, response.username);

        // Update the current user state
        this.currentUserSubject.next({ userId: response.userId, username: response.username });

        // Set the auth status to true
        this.authStatus.next(true);
      })
    );
  }


  logout(): void {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.usernameKey);
    localStorage.removeItem(this.userIdKey);
    this.authStatus.next(false);
    this.router.navigate(['/']);
  }

  getCurrentUser(): { userId: string; username: string } | null {
    return this.currentUserSubject.value;
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  getUserId() {

  }

  isAuthenticated(): Observable<boolean> {
    return this.authStatus.asObservable();
  }

  private hasToken(): boolean {
    return !!localStorage.getItem(this.tokenKey);
  }
}

interface LoginResponse {
  token: string,
  userId: string,
  username: string
}

