import { Component } from '@angular/core';
import { AuthService } from '../../shared/services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {
  username = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) { }

  onLogin(credentials: { username: string; password: string }) {
    this.authService.login(credentials).subscribe({
      next: () => this.router.navigate(['/']),
      error: (err) => alert('Invalid username or password.')
    });
  }
}
