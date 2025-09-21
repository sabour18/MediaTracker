import { Component, EventEmitter, Output, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../../shared/services/auth/auth.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  username = '';
  password = '';

  hide = signal(true); //hides password


  constructor(private authService: AuthService, private router: Router) { }

  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }

  submitForm() {
    this.authService.register({ username: this.username, password: this.password }).subscribe({
      next: () => {
        this.authService.login({ username: this.username, password: this.password }).subscribe({
          next: () => {
            alert('Account Registered!');
            this.router.navigate(['/']);
          },
          error: () => {
            alert('Registration successful, but login failed. Please try logging in.');
          }
        });
      },
      error: (err) => {
        alert('Error registering account: ' + (err.error?.message || 'Unknown error'));
      }
    });
  }
}
