import { Component, EventEmitter, Output, signal } from '@angular/core';
import { AuthService } from '../../../../shared/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username = '';
  password = '';

  hide = signal(true);
  isAuthenticated: boolean = false;

  constructor(authService: AuthService) { }

  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }

  @Output() loginSubmit = new EventEmitter<{ username: string; password: string }>();

  submitForm() {
    this.loginSubmit.emit({ username: this.username, password: this.password });
  }
}
