import { Component, EventEmitter, Output, signal } from '@angular/core';
import { AuthService } from '../../../../shared/services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username = '';
  password = '';

  hide = signal(true); // hides password

  constructor(private authService: AuthService, private router: Router) { }

  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }


  submitForm() {
    this.authService.login({ username: this.username, password: this.password }).subscribe({
      next: () => {
        this.router.navigate(['/']);
      },
      error: (err) => {
        alert('Invalid username or password.');
      }
    });
  }

  goToRegister() {
    this.router.navigate(['/register']);
  }
}
